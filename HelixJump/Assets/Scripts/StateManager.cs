using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static States State;
    public enum States
    {
        Play, End, Dead
    }
    private void Awake()
    {
        State = States.Play;
    }
}
