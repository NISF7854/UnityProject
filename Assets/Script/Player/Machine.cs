using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public PlayerState currentState {  get; private set; }

    public void Initialize(PlayerState startState)
    {
        currentState = startState;
        currentState.Enter();

    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        currentState.Update();
    }

}
