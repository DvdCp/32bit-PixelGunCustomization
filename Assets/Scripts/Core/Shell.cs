using UnityEngine;

public class Shell : MonoBehaviour
{
  
    Rigidbody2D _rb;

    void Start()
    {   
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible() {
      Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }

}
