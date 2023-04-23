using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))] // requires the GameObject to have a Rigidbody component.
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2D;
    protected bool isKnockback = false;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }

    [SerializeField]
    protected float currentVelocity = 3f;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0) // magnityude mean 3 4 5 üçgeni
        {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0) // The Dot Vector product allows us to get the value between (-1 ; 1) where 1 means that the both vectors are pointing in the same direction and -1 that vectors are pointing in opposite directions.
            {
                currentVelocity = 0;

            }
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);



    }
    // public void MoveAgent(Vector2 movementInput)
    // {
    //     movementDirection = movementInput; // we are saving their movement ınput as the movement direction.
    //     currentVelocity = CalculateSpeed(movementInput);



    // }

    private float CalculateSpeed(Vector2 movementInput) // calculate how fast should our player move
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime; // eğer player herhangi bir yere hareket ederse datadan hızlanmasını sağlıyor
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;

        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);

    }
    private void FixedUpdate() // rigidbodyleri herzaman fixed update içinde yap
    {
        OnVelocityChange?.Invoke(currentVelocity);

        if (isKnockback == false)
        {

            rigidbody2D.velocity = currentVelocity * movementDirection.normalized; // normalized means direction of the player
        }




    }
    public void StopMovementOnDie()
    {
        currentVelocity = 0;
        rigidbody2D.velocity = Vector2.zero;
    }
    public void Knockback(Vector2 direction, float power, float duration)
    {
        if (isKnockback == false) // sürekli olmamasını sağladık.
        {
            isKnockback = true;
            StartCoroutine(KnockbackCoroutine(direction, power, duration));

        }
    }
    public void ResetKnockback()
    {
        StopAllCoroutines();
        StopCoroutine("KnockbackCoroutine");
        ResetKnockbackParameters();


    }
    IEnumerator KnockbackCoroutine(Vector2 direction, float power, float duration)
    {
        rigidbody2D.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockbackParameters();
    }

    private void ResetKnockbackParameters()
    {
        currentVelocity = 0;
        rigidbody2D.velocity = Vector2.zero;
        isKnockback = false;
    }
}
