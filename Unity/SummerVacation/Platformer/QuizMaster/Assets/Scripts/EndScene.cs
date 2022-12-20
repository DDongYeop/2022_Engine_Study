using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoreTxt;
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFInalSocre()
    {
        finalscoreTxt.text = "클리어하셨습니다 !\n당신의 스코어는 " + _scoreKeeper.CalculateScore() + "% 입니다 !";
    }
}
