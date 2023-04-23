using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

    }
    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1;

    }
    public void ModifyTimeScale(float endTimeValue, float timeToWait, Action OnCompleteCallBack = null)
    {
        // action kısmı that we can rerun our modified time scale to go back to our basic time values of 1.
        StartCoroutine(TimeScaleCoroutine(endTimeValue, timeToWait, OnCompleteCallBack));

    }
    IEnumerator TimeScaleCoroutine(float endTimeValue, float timeToWait, Action OnCompleteCallBack)
    {
        yield return new WaitForSecondsRealtime(timeToWait); //Oyun zamanından bağımsız şekilde, gerçek zamana göre saniye cinsinden değer vermemizi sağlayan yapıdır.
        Time.timeScale = endTimeValue;
        OnCompleteCallBack?.Invoke(); // if it is not null call ınvoke.

    }
}
