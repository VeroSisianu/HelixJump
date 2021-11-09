using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScoreText;

    void Update()
    {
        if (ScoreText.text != ScoreManager.CurrentScore.ToString())
        {
            ScoreText.text = ScoreManager.CurrentScore.ToString();
        }
        if(BestScoreText.text != "BEST : " + ScoreManager.BestScore)
        {
            BestScoreText.text = "BEST : " + ScoreManager.BestScore;
        }
    }
}
