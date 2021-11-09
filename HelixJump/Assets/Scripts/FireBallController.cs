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


    private float _finalYJumpPosition;
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
        if(_isFalling)
        {
            transform.position += Vector3.down * Time.deltaTime * FallSpeed;
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isFalling = false;
            _beginningJumpPos = transform.position;
            _finalYJumpPosition = _beginningJumpPos.y + JumpHeight;
            transform.DOLocalMoveY(_finalYJumpPosition, JumpDuration);
            transform.DOScale(_scaleOnCollision, ScaleDurationOnCollision);
        }
    }
}
