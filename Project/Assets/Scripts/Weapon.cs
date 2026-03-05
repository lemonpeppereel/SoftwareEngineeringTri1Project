using UnityEngine;

public abstract class Weapon : ScriptableObject, IWeapon
{
    public new string name;
    public int health;
    public int speed;
    public int damage;

    public string Name => name;
    public int Health => health;
    public int Speed => speed;
    public int Damage => damage;

    public abstract void OnHit(Ball ball);
}


// [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
// public abstract class Weapon : ScriptableObject
// {
//     public new string name;
//     public int health;
//     public int speed;   
//     public int damage; 

//     public abstract void OnHit(Ball ball);

// }
