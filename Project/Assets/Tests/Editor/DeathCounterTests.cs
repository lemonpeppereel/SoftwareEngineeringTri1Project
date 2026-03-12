using NUnit.Framework;
using NSubstitute;
using UnityEngine;

public class DeathCounterTests
{
    // Builds a WeaponHealth GameObject with a mock IDeathCounter injected
    private WeaponHealth MakeWeaponHealth(IDeathCounter mock)
    {
        var go = new GameObject("TestWeapon");
        go.AddComponent<SpriteRenderer>();
        var health = go.AddComponent<WeaponHealth>();
        health.Inject(mock);
        return health;
    }

    // Tests that Die() calls IncrementDeathCounter() exactly once
    [Test]
    public void Die_IncrementsDeathCounterOnce()
    {
        var mock = Substitute.For<IDeathCounter>();
        var health = MakeWeaponHealth(mock);

        health.Die();

        mock.Received(1).IncrementDeathCounter();
    }

    // Tests that three separate weapons dying increments the counter three times
    [Test]
    public void Die_CalledThreeTimes_CountIsThree()
    {
        var mock = Substitute.For<IDeathCounter>();

        for (int i = 0; i < 3; i++)
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();
            var wh = go.AddComponent<WeaponHealth>();
            wh.Inject(mock);
            wh.Die();
        }

        mock.Received(3).IncrementDeathCounter();
    }

    // Tests that Die() doesn't crash when no IDeathCounter has been injected
    [Test]
    public void Die_WithNoInjectedCounter_DoesNotThrow()
    {
        var go = new GameObject("TestWeapon");
        go.AddComponent<SpriteRenderer>();
        var health = go.AddComponent<WeaponHealth>();

        Assert.DoesNotThrow(() => health.Die());
    }

    // Tests that replacing the injected counter means only the new one receives the increment
    [Test]
    public void Inject_CanReplaceCounter_NewCounterReceivesIncrement()
    {
        var firstMock  = Substitute.For<IDeathCounter>();
        var secondMock = Substitute.For<IDeathCounter>();
        var health = MakeWeaponHealth(firstMock);

        health.Inject(secondMock);
        health.Die();

        firstMock.DidNotReceive().IncrementDeathCounter();
        secondMock.Received(1).IncrementDeathCounter();
    }
}