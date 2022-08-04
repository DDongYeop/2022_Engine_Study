using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header ("Question")]
    [SerializeField] TextMeshProUGUI questionTxt;
    [SerializeField] List<QuestionSO> questionList = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header ("ANswer")]
    [SerializeField] GameObject[] answerButton;
    private bool _hasAnsweredEarly = true;

    [Header("Button Image")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header ("Timer")]
    [SerializeField] Image timerImage;
    private Timer _timer;


    private void Start()
    {
        _timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        timerImage.fillAmount = _timer.fillFraction;

        if (_timer.loadNextQuestion)
        {
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _timer.loadNextQuestion = false;
        }
        else if (!_hasAnsweredEarly && !_timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        questionTxt.text = currentQuestion.Question;

        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI button = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            button.text = currentQuestion.GetAnswer(i);
        }
    }

    private void GetNextQuestion()
    {
        if (questionList.Count == 0)
            return;

        SetButtonState(true);
        SetDefaultButtonSprte();
        GetRandomQuestion();
        DisplayQuestion();
    }

    private void GetRandomQuestion()
    {
        int rand = Random.Range(0, questionList.Count);
        currentQuestion = questionList[rand];
        
        //questionList.RemoveAt(rand);
        if (questionList.Contains(currentQuestion))
            questionList.Remove(currentQuestion);
        
    }

    private void SetDefaultButtonSprte()
    {
        for (int i = 0; i < 4; i++)
        {
            Image button = answerButton[i].GetComponentInChildren<Image>();
            button.sprite = defaultAnswerSprite;
        }
    }

    public void OnAnsweredSelected(int index)
    {
        _hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        _timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        Image thisImage = answerButton[currentQuestion.CorrectAnswerIndex].GetComponent<Image>();
        
        if (index == currentQuestion.CorrectAnswerIndex)
            questionTxt.text = "맞습니다 ! ";
        else
        {
            string correctAnswer = currentQuestion.GetAnswer(currentQuestion.CorrectAnswerIndex);
            questionTxt.text = "틀렸습니다 ! \n 답은 \"" + correctAnswer + "\" 입니다!";
        }
        thisImage.sprite = correctAnswerSprite;
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < 4; i++)
        {
            Button button = answerButton[i].GetComponentInChildren<Button>();
            button.interactable = state;
        }
    }
}
