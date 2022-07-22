using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    [SerializeField] float fireRateo = 15f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shell;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject shutter;
    [SerializeField] private Animator _animator;

    private AnimationClip[] clips;
    private int reloadTime;

    // Rounds per mag can be changed when a different mag is equipped
    private int roundsPerMag = 30;
    public int RoundsPerMag { get => roundsPerMag; set => roundsPerMag = value; }
    private int remainingRounds;

    private float nextTimeToShoot = 0f;
    private bool isHoldingTrigger = false;
    private bool canClickAsDryGun = true;   // Initially can click as dry gun
    private bool isReloading = false;

    private AudioSource[] gunAudios;
    private AudioSource source;

    private AudioClip normalGunShot;    
    private AudioClip dryGun;
    private AudioClip reloadSound;

    // This is clip that will be played. If a silencer is equipped, silenced shot is played (see ApplySilencedSound.cs)
    private AudioClip actualShotSound;
    public AudioClip ActualShotSound 
    {  
        get { return actualShotSound; }
        set { if (value != null)
                actualShotSound = value;
              else
                actualShotSound = normalGunShot;
            }         
    }

    private void Awake()
    {
        gunAudios = GetComponents<AudioSource>();
        source = gunAudios[0];
        normalGunShot = gunAudios[0].clip;
        dryGun = gunAudios[1].clip;
        reloadSound = gunAudios[2].clip;

        // Setting actualShotSound as normal one
        ActualShotSound = normalGunShot;

        // Getting all animations duration
        clips = _animator.runtimeAnimatorController.animationClips;

        // Selecting onle "reload" animation and get its duration
        foreach (var clip in clips)
            if (clip.name == "reload")
            {
                reloadTime = (int)clip.length;
                print(reloadTime);
            }

        // Initializing rounds in mag
        remainingRounds = roundsPerMag;

    }

    private void Update()
    {
        if (isHoldingTrigger && Time.time >= nextTimeToShoot && !isReloading)
        {
            if (remainingRounds > 0)
            {
                remainingRounds--;

                // Fire effects
                _animator.SetTrigger("fire");
                source.PlayOneShot(ActualShotSound);

                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                Instantiate(shell, shutter.transform.position, shutter.transform.rotation);

            }
            else if (canClickAsDryGun)
            {
                // *Click* ! Empty mag ...
                source.PlayOneShot(dryGun);
                canClickAsDryGun = false;
            }

            nextTimeToShoot = Time.time + 1f / fireRateo;

        }

    }

    // This function is triggered by PlayerInput component.
    // This is the only way to "simulate" hold behaviour like old input system
    public void onFire(InputAction.CallbackContext context)
    {
        if (context.performed)
            isHoldingTrigger = true;

        if (context.canceled)
        { 
            isHoldingTrigger = false;   
            
            // Resetting *Click* when trigger is released
            canClickAsDryGun = true;
        }
    }

    public void onReload(InputAction.CallbackContext context)
    {
        if (context.started && !isReloading)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        _animator.SetTrigger("reload");
        source.PlayOneShot(reloadSound);

        yield return new WaitForSeconds(reloadTime);

        remainingRounds = roundsPerMag;
        //ammoCount.text = "" + _roundsInMag;
        //_anim.SetBool("isOutOfAmmo", false);

        isReloading = false;
    }
}
