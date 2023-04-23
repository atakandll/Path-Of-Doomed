using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecisions : AIDecision // if the distance between our enemy and the object or our targer is within a range
{
    [field: SerializeField]
    [field: Range(0.1f, 15)]
    public float Distance { get; set; } = 5;
    public override bool MakeADecision()
    {
        if (Vector3.Distance(enemyAIBrain.Target.transform.position, transform.position) < Distance)
        {
            if (aIActionData.TargetSpotted == false)
            {
                aIActionData.TargetSpotted = true;
            }

        }
        else
        {
            aIActionData.TargetSpotted = false;
        }
        return aIActionData.TargetSpotted;


    }
#if UNITY_EDITOR 
    protected void OnDrawGizmos() // gizmos is a method that is implemented for the debug purposes
    {
        if (UnityEditor.Selection.activeObject == gameObject) // when we click in our inspector on a object, this active object
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Distance); // gizmosu çizdiğimiz yer
            Gizmos.color = Color.white; // deafult rengine döndürdük.

        }

    }
#endif
}
