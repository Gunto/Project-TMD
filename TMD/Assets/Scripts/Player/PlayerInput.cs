using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private TriggerInteract trigger;
    private DropItem dropScript;
    private SetItemAsActive[] UIItems;
    private CombineItems combineScript;
    private PlayerInventory inv;

    private Transform test;

    void Start()
    {
        UIItems = GameObject.FindGameObjectWithTag("Item UI").GetComponentsInChildren<SetItemAsActive>();
        combineScript = GameObject.FindGameObjectWithTag("Item Manager").GetComponent<CombineItems>();
        inv = PlayerInventory.Instance;
        trigger = GetComponent<TriggerInteract>();
        dropScript = GameObject.FindGameObjectWithTag("Player Manager").GetComponent<DropItem>();

        // IItem doesn't have access to the gameobject it is attached to
        test = Resources.Load<GameObject>("TestPrefab").GetComponent<Transform>();
        // Debug.Log(test.gameobject);
    }

    void Update()
    {
        // Pickup item
        if (Input.GetKeyDown(KeyCode.Space))
        {
            trigger.PickupItem();
        }
        // Drop item
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dropScript.Drop();
        }
        // Switch item
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //UI Switch
            foreach (SetItemAsActive item in UIItems)
            {
                item.SwitchItem();
            }
        }

    }

    // W.I.P. Combine functionality
    private void Temp()
    {
        // Combine items
        if (Input.GetKeyDown(KeyCode.C))
        {
            string output = combineScript.CombineItem(inv.Inventory[0].ItemName, inv.Inventory[1].ItemName);
            // If combination exists
            if (output != null)
            {
                // Assuming you can only hold two items and the two become one
                inv.Inventory.Clear();
                // Who knows if this will even work
                GameObject item = Resources.Load<GameObject>(output);
                inv.AddToInventory(item.GetComponent<IItem>());
            }
        }
    }
}
