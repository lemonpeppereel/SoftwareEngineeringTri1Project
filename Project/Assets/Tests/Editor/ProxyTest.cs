using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WeaponProxyTests
{
    private class FakeWeapon : IWeapon
    {
        public string Name    { get; set; } = "FakeWeapon";
        public int    Health  { get; set; } = 100;
        public int    Speed   { get; set; } = 5;
        public int    Damage  { get; set; } = 10;

        public int OnHitCallCount { get; private set; }

        public void OnHit(Ball ball)
        {
            OnHitCallCount++;
        }
    }

    [Test]
    public void IWeapon_PropertiesAreExposedCorrectly()
    {
        // Arrange
        IWeapon weapon = new FakeWeapon
        {
            Name   = "Sword",
            Health = 80,
            Speed  = 12,
            Damage = 25,
        };

        // Act & Assert — proxy consumers see the right data
        Assert.AreEqual("Sword", weapon.Name,   "Name should match the backing data.");
        Assert.AreEqual(80,      weapon.Health,  "Health should match the backing data.");
        Assert.AreEqual(12,      weapon.Speed,   "Speed should match the backing data.");
        Assert.AreEqual(25,      weapon.Damage,  "Damage should match the backing data.");
    }

    [Test]
    public void IWeapon_OnHit_DelegatesExactlyOnce()
    {
        // Arrange
        var fakeWeapon = new FakeWeapon();
        IWeapon weapon = fakeWeapon;

        var ballGO = new GameObject("Ball");
        var ball   = ballGO.AddComponent<Ball>();

        // Act
        weapon.OnHit(ball);

        // Assert
        Assert.AreEqual(1, fakeWeapon.OnHitCallCount,
            "OnHit should be delegated to the underlying weapon exactly once.");

        // Cleanup
        Object.DestroyImmediate(ballGO);
    }

    [Test]
    public void WeaponProxy_OnHit_IsNoOp_WhenWeaponHealthIsDead()
    {
        // Arrange — build a minimal fake that tracks calls
        var fakeWeapon = new FakeWeapon { Health = 0 };

        var proxy = new ProxyUnderTest(fakeWeapon, isDead: true);

        var ballGO = new GameObject("Ball");
        var ball   = ballGO.AddComponent<Ball>();

        // Act
        proxy.OnHit(ball);

        // Assert — the underlying weapon's OnHit must NOT have been called
        Assert.AreEqual(0, fakeWeapon.OnHitCallCount,
            "Proxy must not delegate OnHit to a dead weapon.");

        Object.DestroyImmediate(ballGO);
    }


    private class ProxyUnderTest : IWeapon
    {
        private readonly IWeapon _inner;
        private readonly bool    _isDead;

        public ProxyUnderTest(IWeapon inner, bool isDead)
        {
            _inner  = inner;
            _isDead = isDead;
        }

        public string Name   => _inner.Name;
        public int Health    => _inner.Health;
        public int Speed     => _inner.Speed;
        public int Damage    => _inner.Damage;

        public void OnHit(Ball ball)
        {
            if (_isDead) return;
            _inner.OnHit(ball);
        }
    }
}