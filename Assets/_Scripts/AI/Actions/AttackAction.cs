using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aIMovementData.Direction = Vector2.zero; // saldırırken hareket etmeyecek.
        aIMovementData.PointOfInterest = enemyAIBrain.Target.transform.position; // yönü playere dönük olucak.
        enemyAIBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
        aIActionData.Attack = true;
        enemyAIBrain.Attack();
    }

}
