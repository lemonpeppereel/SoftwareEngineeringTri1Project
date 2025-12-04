using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed = 5;
    public float rotationSpeed = 360f;
    private bool forwardRotation = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Random initial movement direction
        direction = Random.insideUnitCircle.normalized;
        // Constant velocity movement
        rb.linearVelocity = direction * speed;
    }

    void Update()
    {
        if (forwardRotation)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the normal of the collision surface
        Vector2 normal = collision.contacts[0].normal;

        // Reflect current direction off the collision normal
        direction = Vector2.Reflect(direction, normal).normalized;

        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Weapon"))
        {
            forwardRotation = !forwardRotation;
            Debug.Log("Collision detected");
        }
    }
}
