using UnityEngine;

public interface IBall
{
    Rigidbody2D Rb { get; }
    Vector2 Direction { get; }
    float RotationSpeed { get; set; }
    bool ForwardRotation { get; set; }
    float Speed { get; }
    int Damage { get; }
    string TargetTag { get; }
    string WeaponTag { get; }
    SpriteRenderer WeaponSpriteRenderer { get; }

    void Rotate();
    void WeaponHit(Collision2D collision);
    void BallHit(Collision2D collision);

}
