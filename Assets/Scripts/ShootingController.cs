using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;

    private void Start() 
    {
        _anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    public void onFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("R1 pressed");
             _anim.SetTrigger("fire");
             Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
             //_anim.SetBool("isFiring", false);
        }

        if(context.canceled)
        {
            Debug.Log("R1 released");
        }
           
    }

}
