using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void LateUpdate() 
    {
        Vector3 position = transform.position;
        position.x = playerTransform.position.x;
        transform.position = position;
    }
}
