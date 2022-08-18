using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Ŭ���� �� �ν��Ͻ�
    // Ŭ���� Ʋ, Ŭ������ �̿��� ������� ��ü
    // �л��̶�� Ŭ���� (����, ��, ����, �̸�)
    // Student => StudentŬ������ �̸��� ���� ���̾�?
    // ������ Ŭ������ �׺ϼ� �ν��Ͻ�
    public static TimeController Instance;

    private void Awake()
    {
        Instance = this; // �̰� ���߿� �ڵ� ���� �ҰŴ�.
    }

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1.0f;
    }

    public void ModifyTimeScale(float targetValue, float timeWait, Action OnComplete = null)
    {
        StartCoroutine(TimeScaleCorutine(targetValue, timeWait, OnComplete));
    }

    //0.05�� �ִٰ� Ÿ�ӽ��� 0.2�� ����߷���, () => �ٽ� �ڷ�ƾ�� ���� ���Ѽ� 0.2�� �Ŀ� 1�� ����
    IEnumerator TimeScaleCorutine(float targetValue, float timeToWait, Action Oncomplete = null)
    {
        yield return new WaitForSecondsRealtime(timeToWait); //�̳༮�� Ÿ�ӽ����Ͽ� ������ ���� �ʴ´�
        Time.timeScale = targetValue;
        Oncomplete?.Invoke();
    }
}
