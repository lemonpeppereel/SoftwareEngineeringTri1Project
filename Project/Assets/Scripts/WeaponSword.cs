using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Weapons/Sword")]
public class WeaponSword : Weapon
{
    public int damageIncreasePerHit = 1;
    public float rotationSpeedIncreasePerHit = 20f; 
    public override void OnHit(Ball ball)
    {

        ball.damage += damageIncreasePerHit;
        Debug.Log("Current damage: " + ball.damage);

        ball.rotationSpeed += rotationSpeedIncreasePerHit;
        Debug.Log("Current rotation speed: " + ball.rotationSpeed);

    }
}
