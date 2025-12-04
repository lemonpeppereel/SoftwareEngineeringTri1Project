using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
  
    public float rotationSpeed = 360f;
    private bool forwardRotation = true;

    [SerializeField] public float speed;
    [SerializeField] public int damage;
    [SerializeField] private string targetTag; 
    [SerializeField] private string weaponTag;

    public Weapon weaponData;

    [SerializeField] public SpriteRenderer weaponSpriteRenderer; 


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
        direction = Random.insideUnitCircle.normalized; // Random initial movement direction
        rb.linearVelocity = direction * speed; // Constant velocity movement

        if (weaponData != null)
        { 
        damage = weaponData.damage;
        speed = weaponData.speed;

        
        rb.linearVelocity = direction * speed; // Update velocity with the weapon speed

        }
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
        Vector2 normal = collision.contacts[0].normal; // Get the normal of the collision surface

        direction = Vector2.Reflect(direction, normal).normalized; // Reflect current direction off the collision normal

        if (collision.collider.CompareTag("Weapon"))
        {
            Ball otherBall = collision.collider.GetComponentInParent<Ball>();
            otherBall.GetComponent<WeaponHealth>().TakeDamage(damage);
            forwardRotation = !forwardRotation;
            Debug.Log("ball hit weapon");

            weaponData?.OnHit(this);
          
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            forwardRotation = !forwardRotation;
            Debug.Log("ball hit ball");
        }
    }
    
}
