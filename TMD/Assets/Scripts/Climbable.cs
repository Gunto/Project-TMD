using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour
{
    private PlayerController player;
    private BoxCollider2D playerCollider;
    private SpriteRenderer playerSprite;

    void Start()
    {
        player = PlayerController.Instance;
        playerCollider = player.gameObject.GetComponent<BoxCollider2D>();
        playerSprite = player.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col == playerCollider)
        {
            Debug.Log("Climbing");
            player.speed /= 2f;
            playerSprite.color = Color.red;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col == playerCollider)
        {
            playerSprite.color = Color.white;
            player.speed *= 2f;
        }
    }
}
