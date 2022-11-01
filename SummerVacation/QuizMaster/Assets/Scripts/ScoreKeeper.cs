using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _correctAnswers = 0;
    private int _questionSeen = 0;

    public int CorrectAnswers { get { return _correctAnswers; } }

    public void InxrementCorrectAnswers()
    {
        _correctAnswers++;
    }

    public int QuestionSeen { get { return _questionSeen; } }

    public void IncrementQuestionSeen()
    {
        _questionSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(_correctAnswers / (float)_questionSeen * 100);
    }
}
