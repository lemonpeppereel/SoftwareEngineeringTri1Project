using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponDisplay : MonoBehaviour
{
    
    public Weapon weapon;

   public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameText.text =  weapon.name;
        healthText.text = weapon.health.ToString();
        speedText.text = weapon.speed.ToString();
    }

    void Update()
    {
        healthText.text = weapon.health.ToString();
    }

}
