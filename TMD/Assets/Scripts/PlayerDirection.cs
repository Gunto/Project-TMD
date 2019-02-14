using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    #region Singleton
    static PlayerDirection _instance;
    public static PlayerDirection Instance { get { return _instance; } }
    #endregion
    private Vector2 movementDirection;
    private PlayerController player;
    private bool diagonal;

    void Awake()
    {
        _instance = this;
    }

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
            // Works but flips object
            // transform.rotation = Quaternion.LookRotation(movementDirection);

            if (movementDirection.x != 0)
            {
                transform.rotation = Quaternion.Euler(Vector3.forward * -90f * movementDirection.x);
            }
            if (movementDirection.y == 1)
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            if (movementDirection.y == -1)
            {
                transform.rotation = Quaternion.Euler(Vector3.forward * 180f);
            }
        }
    }
}
