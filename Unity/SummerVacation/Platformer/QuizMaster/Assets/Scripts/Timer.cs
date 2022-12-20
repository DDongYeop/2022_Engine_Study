using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 10f; //������ Ǫ�� �ð�
    [SerializeField] float timeToShowCorrectAnswer = 5f; //������ Ȯ���ϴ� �ð�

    public float fillFraction; //Ÿ�̸� �̹����� fillamount �����ϴ� ���� 
    private float _timerValue; //���� �ð�

    public bool isAnsweringQuestion; //������ �ذ��ϴ� �ð����� ������ Ȯ���ϴ� �ð�
    public bool loadNextQuestion; //���� ������ �Ѿ ����


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

        if (isAnsweringQuestion) //������ Ǫ�� ���̸�
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

        else //������ Ǯ�� ���� ������
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
