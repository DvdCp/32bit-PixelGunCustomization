using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] float ejectingRotationSpeed;

    Rigidbody2D _rb;


    void Start()
    {
        // Random ejecting trajectory (backwards)
        float randomX = Random.Range(0.4f, 1f);
        Vector3 ejectingTrajecotry = new Vector3(-randomX/2f, 1f, 0f);

        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(ejectingTrajecotry, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, 360 * ejectingRotationSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible() {
      Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }

}
