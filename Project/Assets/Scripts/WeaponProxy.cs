using UnityEngine;

public class WeaponProxy : MonoBehaviour, IWeapon
{
    [SerializeField] private Weapon weaponData;
    private WeaponHealth weaponHealth;

    private void Awake()
    {
        weaponHealth = GetComponent<WeaponHealth>();
    }

    public string Name => weaponData.name;
    public int Health => weaponData.health;
    public int Speed => weaponData.speed;
    public int Damage => weaponData.damage;

    public void OnHit(Ball ball)
    {
        if (weaponHealth != null && weaponHealth.IsDead())
            return;

        weaponData.OnHit(ball);
    }
}