using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AgentStepAudioPlayer : AudioPlayer
{

    [SerializeField] AudioClip stepClip;

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepClip);

    }
}
