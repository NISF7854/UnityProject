using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateMachine:MonoBehaviour
{
    public EnemyState currentState {  get; private set; }

    public void Initialize(EnemyState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(EnemyState newState)
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
