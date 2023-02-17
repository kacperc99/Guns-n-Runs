using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Muzzle", menuName = "Inventory/Attachment/Muzzle")]
public class Muzzle : ItemObject
{
    public float fireRate;
    public void Awake()
    {
        type = ItemType.Muzzle;
    }
}
