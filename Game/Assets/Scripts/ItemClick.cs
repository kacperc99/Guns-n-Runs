using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour
{
    public HealthBar healthBar;
    public PlayerHP HP;
    public Consumable potion;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
       //GameObject.Find("Player");
    }

    public void Heal()
    {
        //HP.currentHealth += (int)potion.value;
        //healthBar.SetHealth(HP.currentHealth);
        Destroy (parent);
    }
}
