using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "Inventory/Attachment/Ammo")]
public class Ammo : ItemObject
{
    public string ammoType;
    public float damage;
    public void Awake()
    {
        type = ItemType.Ammo;
    }
}
