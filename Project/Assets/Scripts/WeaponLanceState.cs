using UnityEngine;

public abstract class WeaponLanceState
{
    protected WeaponLance lance;
    protected Ball ball;

    public WeaponLanceState(WeaponLance lance)
    {
        this.lance = lance;
    }
    public abstract WeaponLanceState Act();
}
