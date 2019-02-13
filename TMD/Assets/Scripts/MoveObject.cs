using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Vector3 initialDirection;
    private PlayerController player;
    private Rigidbody2D rb;
    private bool diagonal;
    private bool pushing;
    private bool waiting;
    private IEnumerator pushCoroutine;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
        rb = GetComponent<Rigidbody2D>();
        pushing = false;
        waiting = false;
    }

    // Wait to start pushing (Can be used to switch animations too)
    IEnumerator PushCoroutine()
    {
        waiting = true;
        yield return new WaitForSeconds(1);
        pushing = true;
        waiting = false;
        Debug.Log("Can now push");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        diagonal = player.Diagonal;
        // If not moving diagonally into object, determine which direction to push object
        if (!diagonal)
        {
            initialDirection = player.MovementDirection;
        }
        else
        {
            initialDirection = Vector3.zero;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Update player input
        Vector3 updatedDirection = player.MovementDirection;
        diagonal = player.Diagonal;

        // Set direction when possible (if needed)
        if (initialDirection == Vector3.zero && !diagonal)
        {
            initialDirection = player.MovementDirection;
        }

        // Move object if not moving diagonally AND continuing to push in the same direction as initiated
        if (!diagonal && updatedDirection == initialDirection)
        {
            // If not already pushing, start push coroutine
            if (!pushing && !waiting)
            {
                pushCoroutine = PushCoroutine();
                StartCoroutine(pushCoroutine);
            }
            else if (pushing)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = updatedDirection * moveSpeed * Time.fixedDeltaTime;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StopCoroutine(pushCoroutine);
            pushing = false;
            waiting = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        pushing = false;
        waiting = false;
    }
}
