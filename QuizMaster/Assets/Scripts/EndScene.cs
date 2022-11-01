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
        finalscoreTxt.text = "Ŭ�����ϼ̽��ϴ� !\n����� ���ھ�� " + _scoreKeeper.CalculateScore() + "% �Դϴ� !";
    }
}
