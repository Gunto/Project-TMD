// TODO: Add logic for determining which slot item goes in (Active, inactive, backpack?)
// TODO: Finish method logic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region Singleton
    private static PlayerInventory _instance;
    public static PlayerInventory Instance { get { return _instance; } }
    #endregion

    private List<IItem> inventory;

    // Property
    public List<IItem> Inventory { get { return inventory; } }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        inventory = new List<IItem>(2);
    }

    // Add an item to the inventory
    public void AddToInventory(IItem item)
    {
        // Check if item is in inventory and stackable
        if (PlayerHasItem(item))
        { // Add && isStackable
            // Change stack amount (Stack limit?)
        }
        else
        {
            inventory.Add(item);
        }
    }

    // Incomplete method - Add multiples of an item to the inventory
    public void AddToInventory(IItem item, int amount)
    {
        if (PlayerHasItem(item))
        {
            // Same as above
        }
        // else if (){
        // If stackable, add in one slot
        // }
        else
        {
            // Add amount of item to inventory
            for (int i = 0; i < amount; i++)
            {
                inventory.Add(item);
            }
        }
    }

    // Remove an item from the inventory
    public void RemoveFromInventory()
    {
        // Removes the active item
        foreach (IItem item in inventory)
        {
            if (item.ActiveItem)
            {
                inventory.Remove(item);
                return;
            }
        }
    }

    // Incomplete method - Remove multiples of an item from the inventory
    public void RemoveFromInventory(IItem item, int amount)
    {
        // Add logic for removing X of item
        inventory.Remove(item);
    }

    // Check if player has the item
    public bool PlayerHasItem(IItem item)
    {
        bool result = false;
        foreach (IItem i in inventory)
        {
            if (i.ItemName == item.ItemName)
            {
                result = true;
            }
        }

        return result;
    }
}
