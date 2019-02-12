using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    // Access property for movementDirection
    private Vector2 movementDirection;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        // Vector3 realDirection = Camera.main.transform.TransformDirection(movementDirection);
        // // this line checks whether the player is making inputs.
        // if (realDirection.magnitude > 0.1f)
        // {
        //     Quaternion newRotation = Quaternion.LookRotation(realDirection);
        //     transform.rotation = newRotation;
        //     Debug.Log(gameObject.transform.forward);
        // }

        // Grossly designed, but does the job
        movementDirection = player.MovementDirection;
        if (movementDirection != Vector2.zero)
        {
            if (movementDirection == Vector2.up)
            {
                transform.rotation = Quaternion.LookRotation(Vector2.up);
            }
            if (movementDirection == Vector2.right)
            {
                transform.rotation = Quaternion.LookRotation(Vector2.right);
            }
            if (movementDirection == Vector2.down)
            {
                transform.rotation = Quaternion.LookRotation(Vector2.down);
            }
            if (movementDirection == Vector2.left)
            {
                transform.rotation = Quaternion.LookRotation(Vector2.left);
            }
        }
    }
}
