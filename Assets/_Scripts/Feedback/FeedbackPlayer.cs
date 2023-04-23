using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour // bütün feedbacklari burdan çağırıcaz
{
    [SerializeField]
    private List<FeedBack> feedBackToPlay = null;

    public void PlayFeedback()
    {
        FinishFeedBack();
        foreach (var feedback in feedBackToPlay)
        {
            feedback.CreateFeedBack();

        }

    }

    private void FinishFeedBack()
    {
        foreach (var feedback in feedBackToPlay)
        {
            feedback.CompletePreviousFeedBack(); // önce bu feedback çalışıcak

        }

    }
}
