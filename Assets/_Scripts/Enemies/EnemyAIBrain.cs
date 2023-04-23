using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput
{
    [field: SerializeField]
    public GameObject Target { get; set; }

    [field: SerializeField]
    public AIState CurrentState { get; private set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    internal void ChangeToState(AIState state)
    {
        CurrentState = state;
    }
    private void Update()
    {
        if (Target == null)
        {
            OnMovementKeyPressed?.Invoke(Vector2.zero); // eğer playera gitmiyosa olduğu yerde durcak.
        }
        else
        {
            CurrentState.UpdateState(); // this will call any action that is assigned to this a stae so far our idle state

        }


    }
    public void Attack()
    {
        OnFireButtonPressed?.Invoke();
    }
    public void Move(Vector2 movementDirection, Vector2 targetPosition)
    {
        OnMovementKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(targetPosition);
    }

    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject; // gameobjecte direkt burdan değer atadık.

    }
}


