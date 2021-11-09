using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int CurrentScore;
    public static int PointsToScore;
    public static int BestScore;
    void Update()
    {
        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
        }
    }
}