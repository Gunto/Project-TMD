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

    private List<GameObject> inventory;

    // Property
    public List<GameObject> Inventory { get { return inventory; } }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        inventory = new List<GameObject>();
        // Set maximum size?
    }

    // Add an item to the inventory
    public void AddToInventory(GameObject item)
    {
        // Check if item is in inventory and stackable
        if (inventory.Contains(item))
        { // Add && isStackable
            // Change stack amount (Stack limit?)
        }
        else
        {
            inventory.Add(item);
        }
    }

    // Incomplete method - Add multiples of an item to the inventory
    public void AddToInventory(GameObject item, int amount)
    {
        if (inventory.Contains(item))
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
    public void RemoveFromInventory(GameObject item)
    {
        // Check if item exists before calling this function? (Here or where called?)
        inventory.Remove(item);
    }

    // Incomplete method - Remove multiples of an item from the inventory
    public void RemoveFromInventory(GameObject item, int amount)
    {
        // Add logic for removing X of item
        inventory.Remove(item);
    }
}
