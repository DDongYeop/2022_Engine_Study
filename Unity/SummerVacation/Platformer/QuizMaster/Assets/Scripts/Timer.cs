using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 10f; //문제를 푸는 시간
    [SerializeField] float timeToShowCorrectAnswer = 5f; //정답을 확인하는 시간

    public float fillFraction; //타이머 이미지의 fillamount 연결하는 변수 
    private float _timerValue; //현제 시간

    public bool isAnsweringQuestion; //문제를 해결하는 시간인지 정답을 확인하는 시간
    public bool loadNextQuestion; //다음 문제로 넘어갈 여부


    private void Update()
    {
        UpdateTime();
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    private void UpdateTime()
    {
        _timerValue -= Time.deltaTime;

        if (isAnsweringQuestion) //문제를 푸는 중이면
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                _timerValue = timeToShowCorrectAnswer;
            }
        }

        else //문제를 풀고 있지 않으면
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                _timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
