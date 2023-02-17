using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stock", menuName = "Inventory/Attachment/Stock")]
public class Stock : ItemObject
{
    public float accuracy;
    public void Awake()
    {
        type = ItemType.Stock;
    }


}
