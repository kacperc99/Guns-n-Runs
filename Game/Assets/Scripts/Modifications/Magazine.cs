using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Magazine", menuName = "Inventory/Attachment/Magazine")]
public class Magazine : ItemObject
{
    public float magazineSize;
    public void Awake()
    {
        type = ItemType.Magazine;
    }
}
