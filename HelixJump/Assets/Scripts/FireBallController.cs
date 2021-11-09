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

    void Start()
    {
        _originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Time.timeScale = 0.5f;
        if (Input.GetKeyDown(KeyCode.Tab))
            Time.timeScale = 1;
        if(StateManager.State == StateManager.States.Dead)
        {
            return;
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
                Debug.Log("set isfalling to true");
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
            Debug.Log("set isfalling to false on collision");
            _isFalling = false;
            _beginningJumpPos = transform.position;
            _finalYJumpPosition = _beginningJumpPos.y + JumpHeight;
            transform.DOLocalMoveY(_finalYJumpPosition, JumpDuration);
            transform.DOScale(_scaleOnCollision, ScaleDurationOnCollision);
        }
    }
}
