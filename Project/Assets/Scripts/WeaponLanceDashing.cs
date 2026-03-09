using UnityEngine;

public class WeaponLanceDashing : WeaponLanceState
{
    private bool collided;

    public WeaponLanceDashing(WeaponLance npc) : base(npc)
    {
        collided = false;
        lance.speed = 10; // can be changed later
        // lance.transform.rotation = Quaternion.identity;
        // ball.rotationSpeed = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("VerticalWall") || collision.gameObject.CompareTag("SideWall"))
        {
            collided = true;
        }
    }

    public override WeaponLanceState Act()
    {
        if (collided)
        {
            return new WeaponLanceNormal(lance);
        }
        else
        {
            return this;
        }
    }
}