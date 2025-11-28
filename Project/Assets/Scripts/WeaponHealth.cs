using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private GameObject weapon;

    private float flashLength = 0.05f; 

    private bool damagePossible;
    private float damageInvincibility; 
    private float damageInvincibilityCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; 
        weapon = GetComponent<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!damagePossible)
        {
            damageInvincibilityCooldown -= Time.deltaTime;
            if (damageInvincibilityCooldown < 0)
            {
                damagePossible = true;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // puts currentHealth into the range [0, maxHealth]
        StartCoroutine(DamageFlash());

        Debug.Log(weapon.name + " took " + damage + " damage");

        if (IsDead())
        {
            Die(); 
        }
        damagePossible = false;
    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
        {
            return true;
        }    
        return false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red; 
        yield return new WaitForSeconds(flashLength);
        spriteRenderer.color = Color.hotPink;; // this will be changed once there are real sprites added
    }

}
