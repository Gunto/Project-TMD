using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private PlayerInventory inv;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        inv = PlayerInventory.Instance;
        playerSprite = PlayerController.Instance.GetComponent<SpriteRenderer>();
    }

    public void Drop()
    {
        // Get player location
        Vector3 playerLocation = playerSprite.bounds.center;
        // Spawn item at location
        Instantiate(Resources.Load(inv.Inventory[0].ItemName) as GameObject, playerLocation, Quaternion.identity);
        // Remove item from inventory
        inv.RemoveFromInventory();
    }
}
