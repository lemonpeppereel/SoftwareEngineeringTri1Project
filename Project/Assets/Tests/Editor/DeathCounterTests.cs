using NUnit.Framework;
using UnityEngine;

public class DeathCounterTests
{
    private (WeaponHealth health, MockDeathCounter mock) MakeWeaponHealth()
    {
        var go     = new GameObject("TestWeapon");
        go.AddComponent<SpriteRenderer>(); // required by WeaponHealth.Start()
        var health = go.AddComponent<WeaponHealth>();
        var mock   = new MockDeathCounter();
        health.Inject(mock);
        return (health, mock);
    }

    [Test]
    public void MockCounter_StartsAtZero()
    {
        var mock = new MockDeathCounter();
        Assert.AreEqual(0, mock.DeathCount);
    }

    [Test]
    public void Die_IncrementsDeathCounterOnce()
    {
        var (health, mock) = MakeWeaponHealth();
        health.Die();
        Assert.AreEqual(1, mock.DeathCount);
    }

    [Test]
    public void Die_CalledThreeTimes_CountIsThree()
    {
        var mock = new MockDeathCounter();
        for (int i = 0; i < 3; i++)
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();
            var wh = go.AddComponent<WeaponHealth>();
            wh.Inject(mock);
            wh.Die();
        }
        Assert.AreEqual(3, mock.DeathCount);
    }

    [Test]
    public void Inject_CanReplaceCounter_NewCounterReceivesIncrement()
    {
        var (health, firstMock) = MakeWeaponHealth();
        var secondMock = new MockDeathCounter();
        health.Inject(secondMock);
        health.Die();
        Assert.AreEqual(0, firstMock.DeathCount);
        Assert.AreEqual(1, secondMock.DeathCount);
    }
}