using UnityEngine;

public interface IBall
{
    Rigidbody2D Rb { get; }
    Vector2 Direction { get; }
    float RotationSpeed { get; }
    bool ForwardRotation { get; }
    float Speed { get; }
    int Damage { get; }
    string TargetTag { get; }
    string WeaponTag { get; }
    SpriteRenderer WeaponSpriteRenderer { get; }

    private void Rotate();
    private void WeaponHit(Collision2D collision);
    private void BallHit(Collision2D collision);

}
