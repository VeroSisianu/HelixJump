using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FireBallController : MonoBehaviour
{
    public float JumpDuration = 2f;
    public float FallSpeed = 2f;
    public float JumpHeight = 2f;
    public float ScaleDurationOnCollision;
    public float ScaleDurationAfterCollision;


    private float _finalYJumpPosition = 9;
    private bool _isFalling = true;
    private Vector3 _beginningJumpPos;
    private Vector3 _scaleOnCollision = new Vector3(1.3f, 0.63f, 0.8f);
    private Vector3 _verticalScaleAfterCollision = new Vector3(0.63f, 1.3f, 0.8f);
    private Vector3 _originalScale;
    private MeshRenderer _fireBallRenderer;
    private Color _fastColor;
    private Color _originalColor;
    private ParticleSystem FX_Fire;
    void Start()
    {
        _originalScale = transform.localScale;
        _originalColor = GetComponent<MeshRenderer>().material.color;
        _fireBallRenderer = GetComponent<MeshRenderer>();
        _fastColor = Color.magenta;
        FX_Fire = GetComponentInChildren<ParticleSystem>(true);
    }

    void Update()
    {
        if (ScoreManager.PointsToScore < 30 && _fireBallRenderer.material.color != _originalColor)
        {
            _fireBallRenderer.material.color = _originalColor;
            FX_Fire.gameObject.SetActive(false);
            FallSpeed -= 1.5f;
        }
        else if (ScoreManager.PointsToScore >= 30 && _fireBallRenderer.material.color != _fastColor)
        {
            _fireBallRenderer.material.color = _fastColor;
            FX_Fire.gameObject.SetActive(true);
            FallSpeed += 1.5f;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //    Time.timeScale = 0.5f;
        //if (Input.GetKeyDown(KeyCode.Tab))
        //    Time.timeScale = 1;
        if (StateManager.State == StateManager.States.Dead)
        {
            if(_fireBallRenderer.material.color != _originalColor)
            {
                _fireBallRenderer.material.color = _originalColor;
            }
            return;
        }
        if (StateManager.State == StateManager.States.End && _fireBallRenderer.material.color != _originalColor)
        {
            _fireBallRenderer.material.color = _originalColor;
        }
        if (_isFalling)
        {
            transform.position += Time.deltaTime * FallSpeed * Vector3.down;
        }
        else
        {
            if (transform.position.y >= _finalYJumpPosition)
            {
                _isFalling = true;
            }
            if (transform.position.y >= _finalYJumpPosition - 1f)
            {
                transform.DOScale(_originalScale, ScaleDurationAfterCollision);
            }
            else if (transform.position.y >= _finalYJumpPosition - 1.5f)
            {
                transform.DOScale(_verticalScaleAfterCollision, ScaleDurationAfterCollision);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("FinalGround") && _isFalling)
        {
            _isFalling = false;
            _beginningJumpPos = transform.position;
            _finalYJumpPosition = _beginningJumpPos.y + JumpHeight;
            transform.DOLocalMoveY(_finalYJumpPosition, JumpDuration);
            transform.DOScale(_scaleOnCollision, ScaleDurationOnCollision);
        }
    }
}
