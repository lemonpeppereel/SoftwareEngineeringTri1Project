using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using TMPro;

public class WeaponHealth : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Coroutine damageFlashCoroutine;

    private GameObject weapon;

    private float flashLength = 0.05f; 

    private bool damagePossible;
    private float damageInvincibility = 0.1f; 
    private float damageInvincibilityCooldown = 0.1f;
    
    [SerializeField]
    private TMP_Text healthText;

    private Color originalColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        originalColor = spriteRenderer.color;

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
        
        if (damageFlashCoroutine != null)
        {
            StopCoroutine(damageFlashCoroutine);
            spriteRenderer.color = originalColor;
        }

        damageFlashCoroutine = StartCoroutine(DamageFlash());

        UpdateHealthText();
        Debug.Log("weapon took " + damage + " damage");

        if (IsDead())
        {
            Die(); 
        }

        damagePossible = false;
        damageInvincibilityCooldown = damageInvincibility;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void Die()
    {
        Destroy(gameObject);
        if (DeathCounter.Instance != null)
        {
                DeathCounter.Instance.IncrementDeathCounter();
        }
        Debug.Log("Weapon destroyed");
    }

    public IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red; 
        yield return new WaitForSeconds(flashLength);
        spriteRenderer.color = originalColor;
        damageFlashCoroutine = null;
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

}
