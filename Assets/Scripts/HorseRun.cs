using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRun : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Collider2D frontCollider;
    [SerializeField] private Collider2D bottomCollider;
    private Rigidbody2D rb;
    private bool blocked = false;
    [SerializeField] private bool grounded = false;
    private bool jump_requested = false;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() 
    {  
        blocked = frontCollider.IsTouchingLayers();
        grounded = bottomCollider.IsTouchingLayers();

        if(!blocked && rb.velocity.magnitude < moveSpeed)
        {
            rb.AddForce(Vector2.right * moveSpeed,ForceMode2D.Impulse);
        }

        if(jump_requested)
        {
            if(grounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
}
