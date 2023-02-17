using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Inventory/Gun")]
public class Gun : ItemObject
{

    public Muzzle muzzle;
    public Stock stock;
    public Ammo ammo;
    public Magazine magazine;
    public void Awake()
    {
        //type = ItemType.Gun;
    }


}
