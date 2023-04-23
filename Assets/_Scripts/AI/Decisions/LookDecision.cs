using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField]
    [Range(1, 15)]
    private float distance = 15;
    [SerializeField]
    private LayerMask raycastMask = new LayerMask(); // sadece playerıa takılsın diye diğer collisionlara takılmaması için.

    [field: SerializeField]
    public UnityEvent OnPlayerSpotted { get; set; }

    public override bool MakeADecision()
    {
        var direction = enemyAIBrain.Target.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, raycastMask); // we are only hit specific objects.

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")) // sadece playerde true döndürücek diğer obstacleslarda false döndürücek.
        {
            OnPlayerSpotted?.Invoke();
            return true;
        }
        return false;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject && enemyAIBrain != null && enemyAIBrain.Target != null)
        {
            Gizmos.color = Color.red;
            var direction = enemyAIBrain.Target.transform.position - transform.position;
            Gizmos.DrawRay(transform.position, direction.normalized * distance);
        }

    }
#endif    
}
