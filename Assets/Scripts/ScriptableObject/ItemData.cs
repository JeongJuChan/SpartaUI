using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumable,
}

[CreateAssetMenu(fileName = "DefaultItem", menuName = "CreateItem", order = 1)]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public bool isEquipped;

    [Header("Item Stats")]
    public float attack;
    public float defense;
    public float health;
    public float critical;

    [Header("InGame Equipment")]
    public GameObject equipPrefab;
}
