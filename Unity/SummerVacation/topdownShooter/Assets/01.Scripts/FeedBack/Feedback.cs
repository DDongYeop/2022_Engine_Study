using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void CreateFeedback(); //���� �ǵ���� �����ϴ� �ż���
    public abstract void CompletePrevFeedback(); //���� �ǵ���� ���� ��Ű�� �ż���

    protected virtual void OnDestroy()
    {
        CompletePrevFeedback();
    }

    protected virtual void OnDisable()
    {
        CompletePrevFeedback();
    }
}
