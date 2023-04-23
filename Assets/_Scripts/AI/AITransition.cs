using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    [field: SerializeField]
    public List<AIDecision> Decisions { get; set; } // will ask a couple of decisions, like is player in range of our detection circle and if is player visible

    [field: SerializeField]
    public AIState PositiveResult { get; set; } // decions positive olursa

    [field: SerializeField]
    public AIState NegativeResult { get; set; } // decisons negative olursa
    private void Awake()
    {
        Decisions.Clear();
        Decisions = new List<AIDecision>(GetComponents<AIDecision>()); // no more forgetting the decisions assignmet 

    }
}
