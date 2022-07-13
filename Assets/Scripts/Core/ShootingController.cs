using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    [SerializeField] float fireRateo = 15f;
    [SerializeField] Animator _anim;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shell;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject shutter;

    private float nextTimeToShoot = 0f;
    private bool isShooting = false;

    private void Update()
    {
        while (isShooting && Time.time >= nextTimeToShoot)
        {
            _anim.SetTrigger("fire");

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

}
