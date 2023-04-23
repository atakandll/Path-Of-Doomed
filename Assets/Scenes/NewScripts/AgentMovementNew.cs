using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovementNew : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; } // hızlanma ve yavaşlamasını ayarlamak için buna ulaştık. ve prop haline getirdik

    [SerializeField]
    protected float currentVelocity = 3; // rigidbodye assign etmemiz lazım
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; } // animation için yaptık, float kısmı da agent animation da velocity için float değerini geçtik 

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                currentVelocity = 0;
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        // normalized mean will be direction thay we want yo move in
        rigidbody2d.velocity = currentVelocity * movementDirection.normalized;

    }
}
