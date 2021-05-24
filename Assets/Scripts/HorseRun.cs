using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRun : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3;
    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() 
    {
        
        rb.MovePosition(rb.position + (Vector2.right * moveSpeed * Time.fixedDeltaTime));
    }
}
