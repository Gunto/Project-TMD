using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectRB : MonoBehaviour
{
    private Vector3 initialDirection;
    private PlayerController player;
    private Rigidbody2D rb;
    private bool diagonal;
    public float moveSpeed;
    public float smoothFactor;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
        rb = GetComponent<Rigidbody2D>();
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
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = initialDirection * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }
}
