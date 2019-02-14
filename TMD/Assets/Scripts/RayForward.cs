using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForward : MonoBehaviour
{
    public LayerMask layerMask;
    public float radius;
    public float distance;
    private RaycastHit2D hit2D;
    private Transform playerDirection;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        playerDirection = PlayerDirection.Instance.transform;
        rend = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Project a circle forward from the center of the player
        hit2D = Physics2D.CircleCast(rend.bounds.center, radius, playerDirection.forward, distance, layerMask);
        // Debug.DrawRay(rend.bounds.center, playerDirection.forward * distance, Color.white);

        // If hit something (Can be used in conjunction with layerMask to filter interactions)
        if (hit2D.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Interacting with " + hit2D.collider.gameObject);
            }
        }
    }
}
