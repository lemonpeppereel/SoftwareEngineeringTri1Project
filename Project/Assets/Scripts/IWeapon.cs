public interface IWeapon
{
    string Name { get; }
    int Health { get; }
    int Speed { get; }
    int Damage { get; }
    void OnHit(Ball ball);
}