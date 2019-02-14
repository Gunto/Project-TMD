using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{
    private bool inRange;
    private GameObject obtainableItem;

    // Properties
    public bool InRange { get { return inRange; } }
    public GameObject ObtainableItem { get { return obtainableItem; } }

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;
        // Check if item can be picked up
        obtainableItem = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        obtainableItem = null;
    }
}
