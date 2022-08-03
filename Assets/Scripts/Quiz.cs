using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header ("Question")]
    [SerializeField] TextMeshProUGUI questionTxt;
    [SerializeField] QuestionSO question;

    [Header ("ANswer")]
    [SerializeField] GameObject[] answerButton;

    [Header("Button Image")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    private void Start()
    {
        questionTxt.text = question.Question;


        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI button = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            button.text = question.GetAnswer(i);
        }
    }

    public void OnAnsweredSelected(int index)
    {
        Image thisImage = answerButton[question.CorrectAnswerIndex].GetComponent<Image>();
        
        if (index == question.CorrectAnswerIndex)
            questionTxt.text = "�½��ϴ� ! ";
        else
        {
            string correctAnswer = question.GetAnswer(question.CorrectAnswerIndex);
            questionTxt.text = "Ʋ�Ƚ��ϴ� ! \n ���� " + correctAnswer + " �Դϴ�!";
        }
        thisImage.sprite = correctAnswerSprite;
    }
}
