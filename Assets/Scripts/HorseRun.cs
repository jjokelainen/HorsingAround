using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HorseRun : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float fallingVelocityMinThreshold = 0.3f;
    [SerializeField] private float fallingVelocityMaxThreshold = 1f;
    
    [SerializeField] private Collider2D frontCollider;
    [SerializeField] private Collider2D bottomCollider;
    public UnityEvent JumpEvent;
    public UnityEvent GroundedEvent;
    public UnityEvent FallingEvent;   
    private Rigidbody2D rb;
    private Animator animator;

    private bool blocked = false;
    [SerializeField] private bool grounded = false;
    private bool jump_requested = false;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate() 
    {  
        bool was_grounded = grounded;
        blocked = frontCollider.IsTouchingLayers();
        grounded = bottomCollider.IsTouchingLayers();

        animator.SetBool("Grounded",grounded);
        if(IsFalling())
        {
            FallingEvent.Invoke();    
        }

        if(!was_grounded && grounded)
        {
            GroundedEvent.Invoke();
        }
  
        if(!blocked && rb.velocity.magnitude < moveSpeed)
        {
            rb.AddForce(Vector2.right * moveSpeed,ForceMode2D.Impulse);
        }

        if(jump_requested)
        {
            if(grounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                JumpEvent.Invoke();
            }
            jump_requested = false;
        }       
    }

    private void Update() 
    {
        if(grounded && Input.GetMouseButtonDown(0))
        {
            jump_requested = true;
        }
    }

    public bool IsFalling()
    {
        return -rb.velocity.y > fallingVelocityMinThreshold && rb.velocity.y < fallingVelocityMaxThreshold;
    }
}
