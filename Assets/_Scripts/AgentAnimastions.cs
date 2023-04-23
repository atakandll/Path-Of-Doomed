using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimastions : MonoBehaviour
{

    protected Animator agentAnimator;
    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();
    }
    public void SetWalkAnimations(bool val)
    {
        agentAnimator.SetBool("Walk", val);

    }
    public void AnimatePlayer(float velocity)
    {
        SetWalkAnimations(velocity > 0);
    }
    public void PlayDeathAnimation()
    {
        agentAnimator.SetTrigger("Death");
    }



}
