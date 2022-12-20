using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void CreateFeedback(); //현재 피드백을 실행하는 매서드
    public abstract void CompletePrevFeedback(); //이전 피드백을 종료 시키는 매서드

    protected virtual void OnDestroy()
    {
        CompletePrevFeedback();
    }

    protected virtual void OnDisable()
    {
        CompletePrevFeedback();
    }
}
