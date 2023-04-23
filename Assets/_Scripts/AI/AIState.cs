using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour // this will only start a referece to our actions and transitions
{
    private EnemyAIBrain enemyAIBrain = null; // we hold the reference current state we are in so we need to reference of enemyAIbrain

    [SerializeField]
    private List<AIAction> actions = null;

    [SerializeField]

    private List<AITransition> transitions = null;

    private void Awake()
    {
        enemyAIBrain = transform.root.GetComponent<EnemyAIBrain>();

    }
    public void UpdateState() // enemybraine bakarak action ve transionlara karar veriyor.Yukardaki listlere bakarak
    {

        foreach (var action in actions)
        {
            action.TakeAction();
        }
        foreach (var transition in transitions)
        {
            //player in range -> True -> Back to Idle 
            //player visible -> True -> Chase 

            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeADecision();
                if (result == false)
                    break;
            }
            if (result)
            {
                if (transition.PositiveResult != null)
                {
                    enemyAIBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if (transition.NegativeResult != null)
                {
                    enemyAIBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
            }
        }
    }

}
