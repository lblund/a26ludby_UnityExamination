using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInput))]

public class GeneralPlayer : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D groundChecker;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject menuUI;

    [SerializeField] private Animator anim;
    private const string YVelocity = "YVelocity";
    private const string Running = "Running";
    private const string Grounded = "Grounded";
    
    private Vector2 moveDirection;
    
    private int jumpsRemaining;
    private readonly int extraJumps = 1;

    private bool canMove = true;
    private bool opened = false;    
    
   
    private AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        jumpsRemaining = extraJumps;
    }

    void Update()
    {
        anim.SetFloat(YVelocity, rb.linearVelocityY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocityX = moveDirection.x * moveSpeed;

        if (Mathf.Abs(moveDirection.x) > 0)
        {
            float direction = Mathf.Sign(rb.linearVelocityX);
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
        
        IsGroundedCheck();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        audioSource.Pause();
        if (!canMove) return;
        
        moveDirection = context.ReadValue<Vector2>();
        if (Mathf.Abs(moveDirection.x) > 0)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        
        anim.SetBool(Running, moveDirection.x != 0);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!canMove) return;

        if (!context.performed) return;
        
        if (jumpsRemaining > 0)
        {
            rb.linearVelocityY = jumpForce;
            jumpsRemaining--;
        }
        
    }

    private void IsGroundedCheck()
    {
        bool overlapped = Physics2D.OverlapArea(groundChecker.bounds.min, groundChecker.bounds.max, groundLayer);
        
        if (overlapped)
        {
            jumpsRemaining = extraJumps;
        }
        anim.SetBool(Grounded, overlapped);
    }

    public void SetBoolCanMove(bool value)
    {
        // moveSpeed = value ? moveSpeed : 0;
        if (value)
        {
            moveSpeed = 5;
            moveDirection.x = 0;
        }
        else
        {
            moveSpeed = 0;
        }
        canMove = value;
        anim.SetBool(Running, false);
    }

    public void SettingsMenu()
    {
        opened = !opened;
        
        menuUI.SetActive(opened);
    }

}
