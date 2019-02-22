// TODO: Create interface IObtainableItem to reference
// TODO: Add logic to try and add to inventory and solve after
// TODO: Determine which item to pickup if one item is on top of you and in front
// TODO: Add validation for inventory capacity
// TODO: Swap item

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
        // Check if there is an item and it is obtainable
        if (item != null && item.GetComponent<IItem>() != null) // Change to GetComponent<Interface>() 
        {
            // Add to inventory
            playerInventory.AddToInventory(item.GetComponent<IItem>());
            // Remove from world
            GameObject.Destroy(item);
        }
        else
        {
            Debug.Log("Nothing to pickup");
            return;
        }
    }
}
