using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Qustion", fileName = " new Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)] 
    [SerializeField] string question = "Enter new question text here";

    [SerializeField] string[] answers = new string[4];
    [SerializeField] int corrextAnswerIndex;

    public string Question { get { return question; } }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int CorrectAnswerIndex {  get { return corrextAnswerIndex; } }
}
