using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // 클래스 와 인스턴스
    // 클래스 틀, 클래스를 이용해 만들어진 객체
    // 학생이라는 클래스 (나이, 반, 성별, 이름)
    // Student => Student클래스의 이름의 값은 몇이야?
    // 도서관 클래스의 겜북성 인스턴스
    public static TimeController Instance;

    private void Awake()
    {
        Instance = this; // 이건 나중에 코드 변경 할거다.
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

    //0.05초 있다가 타임스켈 0.2로 떨어뜨려줘, () => 다시 코루틴을 실행 시켜서 0.2초 후에 1로 변경
    IEnumerator TimeScaleCorutine(float targetValue, float timeToWait, Action Oncomplete = null)
    {
        yield return new WaitForSecondsRealtime(timeToWait); //이녀석은 타임스케일에 영향을 받지 않는다
        Time.timeScale = targetValue;
        Oncomplete?.Invoke();
    }
}
