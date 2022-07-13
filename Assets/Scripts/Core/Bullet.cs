using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
  
  Rigidbody2D _rb;

    void Start()
    {
      _rb = GetComponent<Rigidbody2D>();
      _rb.velocity = transform.right * speed;
    }

    private void OnBecameInvisible() {
      Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }

}
