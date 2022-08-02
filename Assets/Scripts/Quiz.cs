using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionTxt;
    [SerializeField] GameObject[] answerButton;
    [SerializeField] QuestionSO question;

    private void Start()
    {
        questionTxt.text = question.Question;


        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI button = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            button.text = question.GetAnswer(i);
        }
    }
}
