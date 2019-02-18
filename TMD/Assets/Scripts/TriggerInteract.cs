// TODO: Create interface IObtainableItem to reference
// TODO: Add logic to try and add to inventory and solve after

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private GameObject item;

    // Property
    public GameObject Item { get { return item; } }

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = PlayerInventory.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        item = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        item = null;
    }

    public void PickupItem()
    {
        // Check if item is obtainable
        if (item != null) // Change to GetComponent<Interface>() 
        {
            // Add to inventory
            playerInventory.AddToInventory(item);
            // Remove from world (Handle here or in inventory?)
            GameObject.Destroy(item);
        }
        else
        {
            return;
        }
    }
}
