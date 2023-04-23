using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionData : MonoBehaviour
{
    [field: SerializeField]
    public bool Attack { get; set; }

    [field: SerializeField]
    public bool TargetSpotted { get; set; } // this will be useful to check if we hve found a target inside our range of the detection 

    [field: SerializeField]
    public bool Arrived { get; set; } // we want to know if our enemy has arrived close enogh to the player to attack again
}
