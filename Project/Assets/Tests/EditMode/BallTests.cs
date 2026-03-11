using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class BallTests
{
    private IBall mockBall;
    private GamObject obj;
    private Ball ball;
    private WeaponHealth weaponHealth;
    private IWeapon mockProxy;

    public void Setup()
    {
        mockBall = Substitute.For<IBall>();

        ball = obj.AddComponent<Ball>();
        weaponHealth = obj.AddComponent<WeaponHealth>();

        mockProxy = Substitute.For<IWeaponProxy>();
        ball.weaponProxy = mockProxy;
    }

    // A Test behaves as an ordinary method
    [Test]
    public void Rotate_ForwardRotationIsTrue()
    {
        // Arrange
        GameObject obj = new GameObject();
        Ball ball = obj.AddComponent<Ball>();

        ball.RotationSpeed = 100f;
        ball.ForwardRotation = true;

        float start = obj.transform.eulerAngles.z;

        // Act
        ball.Rotate();

        float end = obj.transform.eulerAngles.z;

        // Assert
        Assert.Greater(start, end);
    }

    [Test]
    public void Rotate_ForwardRotationIsFalse()
    {
        // Arrange
        GameObject obj = new GameObject();
        Ball ball = obj.AddComponent<Ball>();

        ball.RotationSpeed = 100f;
        ball.ForwardRotation = false;

        float start = obj.transform.eulerAngles.z;

        // Act
        ball.Rotate();

        float end = obj.transform.eulerAngles.z;

        // Assert
        Assert.Lesser(start, end);
    }

    [Test]
    public void Rotate_CalledRotate()
    {
        // Act
        mockBall.Rotate();

        // Assert
        mockBall.Received(1).Rotate();
    }

    [Test]
    public void WeaponHit_BallHitByWeapon()
    {
        // Arrange
        bool initial = ball.ForwardRotation;
        int startHealth = weaponHealth.Health;

        // Act
        ball.WeaponHit(null);

        // Assert
        Assert.AreNotEqual(initial, ball.ForwardRotation);
        mockProxy.Received(1).OnHit(ball);
        Assert.Less(weaponHealth.Health, startHealth);
    }

    public void BallHit_BallHitByAnotherBall()
    {
        // Arrange
        bool initial = ball.ForwardRotation;

        // Act
        ball.BallHit(null);

        // Assert
        Assert.AreNotEqual(initial, ball.ForwardRotation);
    }
}
