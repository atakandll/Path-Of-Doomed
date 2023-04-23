using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseActions : AIAction // we tell enemyBrain we should move and we should move towards our target
{
    public override void TakeAction() // enemy nin nereye gideceğini hesaplıcaz
    {
        var direction = enemyAIBrain.Target.transform.position - transform.position;
        aIMovementData.Direction = direction.normalized;
        aIMovementData.PointOfInterest = enemyAIBrain.Target.transform.position; // we want the enemy to take a look at that player or the target 
        enemyAIBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
    }

}
