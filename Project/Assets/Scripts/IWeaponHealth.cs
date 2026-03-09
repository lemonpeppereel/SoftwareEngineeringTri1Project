using UnityEngine;

public interface IWeaponHealth
{
    string MaxHealth { get; }
    string CurrentHealth { get;}

    SpriteRenderer spriteRenderer { get;}
    
}
