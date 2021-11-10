using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScoreText;
    public Slider PercentsSlider;
    public Transform FireBall;
    float _beginningPos;
    float _finalPos = -15f;
    float _fullDistanceToFinalGround;
    float _pastSliderValue = 0;


    private void Start()
    {
         _beginningPos = FireBall.position.y;
         _fullDistanceToFinalGround = _beginningPos - _finalPos;
    }
    void Update()
    {
        if (ScoreText.text != ScoreManager.CurrentScore.ToString())
        {
            ScoreText.text = ScoreManager.CurrentScore.ToString();
        }
        if(BestScoreText.text != $"BEST : {ScoreManager.BestScore}")
        {
            BestScoreText.text = $"BEST : {ScoreManager.BestScore}";
        }

        var _currentDistanceToFinalGround = FireBall.position.y - _finalPos;
        var _sliderValue = (_fullDistanceToFinalGround - _currentDistanceToFinalGround) / _fullDistanceToFinalGround * 100;
        
        if (_sliderValue <= 100 && _sliderValue >= 0 && _sliderValue > _pastSliderValue)
        {
            PercentsSlider.value = _sliderValue;
        }
        _pastSliderValue = PercentsSlider.value;
    }
}
