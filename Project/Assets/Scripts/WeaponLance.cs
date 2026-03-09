using UnityEngine;

[CreateAssetMenu(fileName = "Lance", menuName = "Weapons/Lance")]
public class WeaponLance : Weapon
{
    public int dashDamageIncrease = 2;

    public override void OnHit(Ball ball)
    {
        ball.damage += dashDamageIncrease;
        Debug.Log("Current damage: " + ball.damage);
    }
}