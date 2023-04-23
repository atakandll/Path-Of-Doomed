using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeFeedback : FeedBack
{
    [SerializeField]
    private float freezeTimeDelay = 0.01f, unfreezeTimeDelay = 0.02f;
    [SerializeField]
    [Range(0, 1)]
    private float timeFreezeValue = 0.2f;
    public override void CompletePreviousFeedBack()
    {
        if (TimeController.instance != null)
        {
            TimeController.instance.ResetTimeScale();

        }
    }

    public override void CreateFeedBack()
    {
        TimeController.instance.ModifyTimeScale(timeFreezeValue, freezeTimeDelay, () => TimeController.instance.ModifyTimeScale(1, unfreezeTimeDelay)); // 1 ile normal time a döndük.
    }
}
