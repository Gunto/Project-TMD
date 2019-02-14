using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }
    #endregion

    public float speed;
    public TriggerInteract trigger;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 m_Velocity = Vector3.zero;
    // private Vector3 moveVelocity = Vector3.zero;
    [SerializeField]
    private Vector2 movementDirection;
    private bool diagonal;
    private SpriteRenderer spriteRenderer;
    private SpriteMask spriteMask;
    [Range(0, .3f)] public float movementSmooth = 0.05f;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (trigger.InRange)
            {
                Debug.Log("Object is: " + trigger.ObtainableItem);
            }
        }
        spriteMask.sprite = spriteRenderer.sprite;
    }

    void UpdateMovement()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        diagonal = movementDirection.x * movementDirection.y != 0 ? true : false;
        // moveVelocity.x = movementDirection.x;
        // moveVelocity.y = movementDirection.y;
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
