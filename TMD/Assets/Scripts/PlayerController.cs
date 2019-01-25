using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 m_Velocity = Vector3.zero;
    private Vector3 moveVelocity = Vector3.zero;
    private SpriteRenderer spriteRenderer;
    private SpriteMask spriteMask;

    [Range(0, .3f)] public float movementSmooth = 0.05f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVelocity.y = Input.GetAxisRaw("Vertical") * speed;
        if (moveVelocity != Vector3.zero)
        {
            animator.SetFloat("moveX", moveVelocity.x);
            animator.SetFloat("moveY", moveVelocity.y);
        }
        spriteMask.sprite = spriteRenderer.sprite;
    }

    void FixedUpdate()
    {
        Move(moveVelocity.x * Time.fixedDeltaTime, moveVelocity.y * Time.fixedDeltaTime);
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 targetVelocity = moveVelocity.normalized * 5f;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmooth);
    }
}
