using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WeaponController : MonoBehaviour
{    
    [SerializeField] private int damage = 10;
    [SerializeField] private string targetTag = "Ball"; //Or whatever it is called

    [SerializeField] public Transform target;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
    }

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            WeaponHealth health = other.GetComponent<WeaponHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("player found and given damage");
            }
        }
    }
}
