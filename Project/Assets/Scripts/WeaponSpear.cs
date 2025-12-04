using UnityEngine;

[CreateAssetMenu(fileName = "Spear", menuName = "Weapons/Spear")]
public class WeaponSpear : Weapon
{
    public float lengthIncreaseAmount = 0.2f;
    public int damageIncreasePerHit = 1;

    public override void OnHit(Ball ball)
    {
        if (ball.weaponSpriteRenderer != null)
        {
        Vector3 scale = ball.weaponSpriteRenderer.transform.localScale;
        scale.x += lengthIncreaseAmount;  // increase width
        scale.y += lengthIncreaseAmount;  // increase height
        ball.weaponSpriteRenderer.transform.localScale = scale;

        Debug.Log("Spear scaled to " + scale);
        }

        ball.damage += damageIncreasePerHit;
        Debug.Log("Current damage: " + ball.damage);

    }
}
