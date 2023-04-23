using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour // what should happen when we go into the state
{
    protected AIActionData aIActionData;
    protected AIMovementData aIMovementData;
    protected EnemyAIBrain enemyAIBrain;

    private void Awake()
    {
        aIActionData = transform.root.GetComponentInChildren<AIActionData>(); // root: En üst seviyedeki parent objesine erişmemizi sağlayan değişkendir. Eğer obje herhangi bir parent objesine sahip değilse objenin kendisini döndürecektir.
        aIMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyAIBrain = transform.root.GetComponent<EnemyAIBrain>(); // enemy gameobject has the enemy brain so we reach top post companent 
    }
    public abstract void TakeAction();




}
