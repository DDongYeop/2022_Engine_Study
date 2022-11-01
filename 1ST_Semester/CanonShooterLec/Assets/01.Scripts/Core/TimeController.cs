using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;
    }

    //ModifyTimeScale(0.2f, 0.1f, () => {});
    public void ModifyTimeScale(float endTimeValue, float timeToWait, Action OnComplete = null)
    {
        StartCoroutine(TimeScaleCorutine(endTimeValue, timeToWait, OnComplete));
    }

    IEnumerator TimeScaleCorutine(float endTimeValue, float timeToWait, Action OnComplete = null)
    {
        yield return new WaitForSecondsRealtime(timeToWait); // 나중에 수정해야함
        Time.timeScale = endTimeValue;
        OnComplete?.Invoke();
    }
}
