using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWithPlatforms : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            ScoreManager.CurrentScore += ScoreManager.PointsToScore;
            ScoreManager.PointsToScore += 10;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ScoreManager.PointsToScore = 10;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StateManager.State = StateManager.States.End;
        }
    }
}
