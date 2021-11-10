using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    void Update()
    {
        if(StateManager.State == StateManager.States.Dead)
        {
            Debug.Log("loaded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (StateManager.State == StateManager.States.End && SceneManager.GetActiveScene().buildIndex + 1 <= 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
