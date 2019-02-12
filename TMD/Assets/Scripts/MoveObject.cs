using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Vector3 initialDirection;
    private PlayerController player;
    private bool diagonal;
    public float moveSpeed;
    public float smoothFactor;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        initialDirection = player.MovementDirection;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 updatedDirection = player.MovementDirection;
        diagonal = updatedDirection.x * updatedDirection.y != 0 ? true : false;

        // Move object
        if (!diagonal && updatedDirection == initialDirection)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + initialDirection, Time.fixedDeltaTime * moveSpeed * smoothFactor);
        }

    }
}
