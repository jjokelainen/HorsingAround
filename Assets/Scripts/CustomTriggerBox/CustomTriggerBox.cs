using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*@brief
Creates a overlapbox to sense colliders in the specified layer
*/
public class CustomTriggerBox : MonoBehaviour
{
    public UnityEvent TriggerboxContactStart;
    public UnityEvent TriggerboxContactEnd;
    [SerializeField] private LayerMask layerMask;
    public Vector2 Point = Vector2.zero;
    public Vector2 Size = Vector2.one;

    //For future use
    public float Angle = 0;
    
    private float minDepth = -Mathf.Infinity;
    private float maxDepth = Mathf.Infinity;

    private bool isTouching = false;
    private bool wasTouching = false;

    private void FixedUpdate() 
    {
        Collider2D[] results = new Collider2D[5]; //Small buffer is OK since currently no processing is done for the contacts
        int resultcount = 0;
        resultcount = Physics2D.OverlapBoxNonAlloc(new Vector2(transform.position.x,transform.position.y) + Point,Size,Angle,results,layerMask,minDepth,maxDepth);
        isTouching = resultcount > 0;
        if(isTouching && !wasTouching){
            TriggerboxContactStart.Invoke();
        }
        if(!isTouching && wasTouching){
            TriggerboxContactEnd.Invoke();
        }
        
    }
    public bool IsTouchingLayers()
    {
        return isTouching;
    }
}
