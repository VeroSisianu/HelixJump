using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    private Animator _anim;
    public Transform PlayerTransform;
    private bool _isFalling;
    public float FallSpeed = 3.0f;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _isFalling = false;
    }

    void Update()
    {
        if(PlayerTransform.position.y < transform.position.y && !_anim.GetCurrentAnimatorStateInfo(0).IsName("A_PlatformDestroy"))
        {
            _anim.Play("A_PlatformDestroy");
        }
        if(_isFalling)
        {
            transform.position += Time.deltaTime * FallSpeed * Vector3.down;
        }
    }

    public void SetFallingToTrue()
    {
        _isFalling = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinalGround"))
        {
            Destroy(gameObject);
        }
    }
}
