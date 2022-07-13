using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _firePoint;

    // Start is called before the first frame update
    public void onFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _anim.SetTrigger("fire");
            Instantiate(_bullet, _firePoint.transform.position, _firePoint.transform.rotation);
            //_anim.SetBool("isFiring", false);
        }

        if(context.canceled)
        {
            Debug.Log("R1 released");
        }
           
    }

}
