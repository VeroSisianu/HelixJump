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
        if (StateManager.State == StateManager.States.End || StateManager.State == StateManager.States.Dead)
            return;
        if (PlayerTransform.position.y < transform.position.y - 2)
        { 
            transform.position += Vector3.down * Time.deltaTime * FallSpeed;
        }
        if(ScoreManager.PointsToScore >= 30)
        {
            FallSpeed = 4.6f;
        }
        else
        {
            FallSpeed = 3.6f;
        }
    }
}
