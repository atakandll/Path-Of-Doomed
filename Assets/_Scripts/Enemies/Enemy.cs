using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockback
{
    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; set; } = 2;

    [field: SerializeField]
    public EnemyAttack enemyAttack { get; set; }

    private bool dead = false;
    private AgentMovement agentMovement;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake()
    {
        if (enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }
        agentMovement = GetComponent<AgentMovement>();

    }


    private void Start()
    {
        Health = EnemyData.MaxHealth;

    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead == false)
        {
            Health -= damage;
            OnGetHit?.Invoke();

            if (Health <= 0)
            {
                dead = true;
                OnDie?.Invoke();


            }

        }

    }
    public void Die()
    {
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if (dead == false) // eğer ölmediyse
        {
            enemyAttack.Attack(EnemyData.Damage);
        }

    }

    public void Knockback(Vector2 direction, float power, float duration)
    {
        agentMovement.Knockback(direction, power, duration);

    }
}
