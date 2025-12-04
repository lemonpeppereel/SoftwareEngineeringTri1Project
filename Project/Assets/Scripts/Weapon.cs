using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public abstract class Weapon : ScriptableObject
{
    public new string name;
    public int health;
    public int speed;   
    public int damage; 

    public abstract void OnHit(Ball ball);

}
