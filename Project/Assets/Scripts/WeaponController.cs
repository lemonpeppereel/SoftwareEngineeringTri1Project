using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WeaponController : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private string targetTag = "Ball"; 
    [SerializeField] private string weaponTag = "Weapon"; // new tag for weapons

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Case 1: Weapon hits a player
        if (other.CompareTag(targetTag))
        {
            WeaponHealth health = other.GetComponent<WeaponHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Player found and given damage");
            }
        }

        // Case 2: Weapon hits another weapon
        if (other.CompareTag(weaponTag))
        {
            Rigidbody2D myRb = GetComponentInParent<Rigidbody2D>();
            Rigidbody2D otherRb = other.GetComponentInParent<Rigidbody2D>();

            if (myRb != null && otherRb != null)
            {
                // Calculate bounce direction
                Vector2 collisionNormal = (transform.position - other.transform.position).normalized;

                // Reflect both players away from each other
                myRb.linearVelocity = Vector2.Reflect(myRb.linearVelocity, collisionNormal);
                otherRb.linearVelocity = Vector2.Reflect(otherRb.linearVelocity, -collisionNormal);

                Debug.Log("Weapons collided and bounced");
            }
        }
    }
}