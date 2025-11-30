using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Random initial movement direction
        direction = Random.insideUnitCircle.normalized;
    }

    void FixedUpdate()
    {
        // Constant velocity movement
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the normal of the collision surface
        Vector2 normal = collision.contacts[0].normal;

        // Reflect current direction off the collision normal
        direction = Vector2.Reflect(direction, normal).normalized;
    }
}
