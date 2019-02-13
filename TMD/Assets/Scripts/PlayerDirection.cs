using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private Vector2 movementDirection;
    private PlayerController player;
    private bool diagonal;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Get direction and input status
        movementDirection = player.MovementDirection;
        diagonal = player.Diagonal;

        // If moving and not diagonal
        if (movementDirection != Vector2.zero && !diagonal)
        {
            // Turn to face input direction
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }
    }
}
