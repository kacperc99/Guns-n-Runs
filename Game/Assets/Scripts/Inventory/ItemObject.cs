using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Gun,
    Muzzle,
    Stock,
    Magazine,
    Ammo,
    Consumable
}
public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public ItemType type;
    [TextArea(15, 20)]
    public string desciption;
    public Sprite ObjectImage;

}
