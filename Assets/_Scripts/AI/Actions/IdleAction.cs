using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        aIMovementData.Direction = Vector2.zero;
        aIMovementData.PointOfInterest = transform.position;
        enemyAIBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
    }
}
