using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public Transform PlayerTransform;
    public float FallSpeed = 3.6f;
    
    void Update()
    {
        if (PlayerTransform.position.y < transform.position.y)
        { 
            transform.position += Vector3.down * Time.deltaTime * FallSpeed;
        }
    }
}
