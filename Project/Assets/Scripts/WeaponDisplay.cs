using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    
    public Weapon weapon;

    public Text nameText;
    public Text healthText;
    public Text speedText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameText.text =  weapon.name;
        healthText.text = weapon.health.toString();
        speedText.text = weapon.speed.toString();
    }

    void Update()
    {
        healthText.text = weapon.health.toString();
    }

}
