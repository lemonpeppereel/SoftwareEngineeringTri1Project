using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Events;
using System;

public class WeaponHealth : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Coroutine damageFlashCoroutine;

    private float flashLength = 0.05f; 

    private bool damagePossible;
    private float damageInvincibility = 0.1f; 
    private float damageInvincibilityCooldown = 0.1f;
    
    [SerializeField]
    private TMP_Text healthText;

    private Color originalColor;

    private IDeathCounter _deathCounter;
    public void Inject(IDeathCounter deathCounter) => _deathCounter = deathCounter;

    public event Action<Vector2> OnHit;
    public event Action<Vector2> OnDeath;
    

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        originalColor = spriteRenderer.color;

        if (_deathCounter == null && DeathCounter.Instance != null)
            _deathCounter = DeathCounter.Instance;
    }

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
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        OnHit?.Invoke(transform.position);

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
        _deathCounter?.IncrementDeathCounter();

        OnDeath?.Invoke(transform.position);

        if (Application.isPlaying)
            Destroy(gameObject);
        else
            DestroyImmediate(gameObject);

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