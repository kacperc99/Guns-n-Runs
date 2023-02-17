using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "Inventory/Consumable")]

public class Consumable : ItemObject
{
    public float value;
    public string ConsumableType;
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
