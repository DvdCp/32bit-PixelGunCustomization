using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    private Vector2 _mousePosition;

    public void onMovement(InputAction.CallbackContext context)
    {
        if(context.control.device.displayName == "Mouse")
        {
            // Getting input values ...
            _mousePosition = context.ReadValue<Vector2>();
            
            // Tracking mouse position and rotatating gun sprite in order to look at it
            Vector3 mouseOnCamera = Camera.main.ScreenToWorldPoint(_mousePosition);
            
            Vector2 direction = mouseOnCamera - transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            transform.eulerAngles = new Vector3 (0, 0, angle);
            
            // Updating Visuals
            if(mouseOnCamera.x < 0)
                transform.localScale = new Vector3(1, -1, 1);     
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Vector2 _stickPosition = context.ReadValue<Vector2>();
        }
    }

    public void resetPosition()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
