using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainableItem : MonoBehaviour, IItem
{
    [SerializeField] private string itemName;
    [SerializeField] private bool obtainable;
    [HideInInspector] private bool activeItem;
    [SerializeField] private Sprite inventorySprite;

    public string ItemName { get { return itemName; } }
    public bool Obtainable { get { return obtainable; } }
    public bool ActiveItem { get { return activeItem; } set { activeItem = value; } }
    public Sprite InventorySprite { get { return inventorySprite; } }
}
