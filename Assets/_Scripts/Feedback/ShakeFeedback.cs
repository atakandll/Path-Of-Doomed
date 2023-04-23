using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShakeFeedback : FeedBack
{
    [SerializeField]
    private GameObject objectToShake = null;
    [SerializeField]
    private float duraiton = 0.2f, strength = 1, randomness = 90;
    [SerializeField]
    private int vibrato = 10;
    [SerializeField]
    private bool snapping = false, fadeout = true; // fadeout mean that it will return their posiiton to this previous posiiton that we have started with 
    public override void CompletePreviousFeedBack()
    {
        objectToShake.transform.DOComplete();
    }

    public override void CreateFeedBack()
    {
        CompletePreviousFeedBack();
        objectToShake.transform.DOShakePosition(duraiton, strength, vibrato, randomness, snapping, fadeout);
    }
}
