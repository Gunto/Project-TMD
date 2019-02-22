using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }
    #endregion

    public float speed;
    private Rigidbody2D rb;
    private Vector3 m_Velocity = Vector3.zero;
    [HideInInspector] private Vector2 movementDirection;
    private bool diagonal;
    [Range(0, .3f)] public float movementSmooth = 0.05f;
    private Animator animator;


    // Properties
    public Vector2 MovementDirection
    {
        get { return movementDirection; }
    }

    public bool Diagonal { get { return diagonal; } }

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        diagonal = movementDirection.x * movementDirection.y != 0 ? true : false;
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("moveX", movementDirection.x);
            animator.SetFloat("moveY", movementDirection.y);
        }
    }

    void FixedUpdate()
    {
        Move(movementDirection.x * Time.fixedDeltaTime, movementDirection.y * Time.fixedDeltaTime);
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 targetVelocity = movementDirection.normalized * speed;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmooth);
    }
}
