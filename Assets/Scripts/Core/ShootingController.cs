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
    private float reloadTime;

    private AudioSource[] gunAudios;
    private AudioSource source;
    private AudioClip gunShot;
    private AudioClip dryGun;
    private AudioClip reloadSound;

    private float nextTimeToShoot = 0f;
    private bool isShooting = false;
    private bool isReloading = false;

    private void Awake()
    {
        gunAudios = GetComponents<AudioSource>();
        source = gunAudios[0];
        gunShot = gunAudios[0].clip;
        dryGun = gunAudios[1].clip;
        reloadSound = gunAudios[2].clip;

        // Getting all animations duration
        clips = _animator.runtimeAnimatorController.animationClips;

        // Selecting onle "reload" animation and get its duration
        foreach(var clip in clips)
            if (clip.name == "reload")
                reloadTime = clip.length;

    }

    private void Update()
    {
        while (isShooting && Time.time >= nextTimeToShoot)
        {
            // Fire effects
            _animator.SetTrigger("fire");
            source.PlayOneShot(gunShot);

            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            Instantiate(shell, shutter.transform.position, shutter.transform.rotation);

            nextTimeToShoot = Time.time + 1f / fireRateo;
        }
    }

    // This function is triggered by PlayerInput component.
    // This is the only way to "simulate" hold behaviour like old input system
    public void onFire(InputAction.CallbackContext context)
    {
        if(context.performed)
            isShooting = true;

        if(context.canceled)
            isShooting = false;    
    }

    public void onReload(InputAction.CallbackContext context)
    {

        if (context.started && !isReloading)
        {
            StartCoroutine(Reload());
        }

    }

    private IEnumerator Reload()
    {
        print(reloadTime);

        isReloading = true;
        _animator.SetTrigger("reload");
        source.PlayOneShot(reloadSound);

        yield return new WaitForSeconds(reloadTime);
        //_roundsInMag = maxRounds;
        //ammoCount.text = "" + _roundsInMag;
        //_anim.SetBool("isOutOfAmmo", false);

        isReloading = false;
    }

}
