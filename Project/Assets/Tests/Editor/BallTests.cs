using UnityEngine;

public class BallTests
{
    // private class MockBall : IBall
    // {
    //     Rigidbody2D Rb { get; }
    //     Vector2 Direction { get; }
    //     float RotationSpeed { get; set; } = 360f;
    //     bool ForwardRotation { get; set; } = true;
    //     float Speed { get; }
    //     int Damage { get; }
    //     string TargetTag { get; }
    //     string WeaponTag { get; }
    //     SpriteRenderer WeaponSpriteRenderer { get; }

    //     private void Rotate();
    //     private void WeaponHit(Collision2D collision);
    //     private void BallHit(Collision2D collision);
    // }

    // [Test]
    // public void Rotate_ForwardRotation()
    // {
    //     // Arrange
    //     var mockBall = new MockBall();
    //     IBall ball = mockBall;
    //     ball.ForwardRotation = true;

    //     // Act
    //     ball.Rotate();

    //     // Assert
    //     Assert.AreEqual(transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime)); // something needed here to compare to
    // }

    // [Test]
    // public void Rotate_BackwardRotation()
    // {
    //     // Arrange
    //     var mockBall = new MockBall();
    //     IBall ball = mockBall;
    //     ball.ForwardRotation = true;

    //     // Act
    //     ball.Rotate();

    //     // Assert
    //     Assert.AreEqual(transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime)); // something needed here to compare with
    // }
}
