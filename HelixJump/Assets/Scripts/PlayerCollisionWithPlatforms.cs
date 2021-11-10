using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWithPlatforms : MonoBehaviour
{
    public GameObject SplashEffectPref;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            ScoreManager.CurrentScore += ScoreManager.PointsToScore;
            ScoreManager.PointsToScore += 10;
            var arrOfColliders = other.gameObject.transform.parent.GetComponentsInChildren<MeshCollider>(false);
            foreach(var i in arrOfColliders)
            {
                i.isTrigger = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ScoreManager.PointsToScore = 10;
            CreateSplashFX(collision);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StateManager.State = StateManager.States.Dead;
        }
        if (collision.gameObject.CompareTag("FinalGround"))
        {
            if(StateManager.State != StateManager.States.End)
            {
                StateManager.State = StateManager.States.End;
            }
            CreateSplashFXFinalGround();
        }
    }

    private void CreateSplashFX(Collision collision)
    {
        var _fxPosition = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        var _randomYRotation = Random.Range(0, 90);
        Instantiate(SplashEffectPref, _fxPosition,Quaternion.Euler(new Vector3(0, _randomYRotation, 0)),collision.transform);
    }
    private void CreateSplashFXFinalGround()
    {
        var _fxPosition = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        var _randomYRotation = Random.Range(0, 90);
        var obj = Instantiate(SplashEffectPref, _fxPosition, Quaternion.Euler(new Vector3(0, _randomYRotation, 0)));
        obj.transform.localScale = new Vector3(.1f, .1f, .1f);
    }
}
