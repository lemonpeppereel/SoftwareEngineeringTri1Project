using UnityEngine;
using System.Collections;

public class WeaponLanceNormal : WeaponLanceState
{
    public float dashReloadTime = 3f;
    private bool waiting;
    private MonoBehaviour runner;

    public WeaponLanceNormal(WeaponLance npc) : base(npc)
    {
        waiting = true;
        lance.speed = 5;
        runner.StartCoroutine(WaitForDash());
    }

    private IEnumerator WaitForDash()
    {
        yield return new WaitForSeconds(dashReloadTime);
        waiting = false;
    }

    public override WeaponLanceState Act()
    {
        if (waiting)
        {
            return this;
        }
        else
        {
            return new WeaponLanceDashing(lance);
        }
    }
}