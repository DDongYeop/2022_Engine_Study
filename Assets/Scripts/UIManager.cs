using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text currentScoreTxt;
    public Text bestScoreTxt;
    int currentScore;
    int bestScore;

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("Current Score", 0);
        currentScoreTxt.text = "�������� : " + currentScore;
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreTxt.text = "�ְ����� : " + bestScore;
    }
    public void BtnRestart() //��Ʈ������ ���������ϰ�
    {
        SceneManager.LoadScene("PlayScene"); //�����Ѱ� ����, on click���� �����൵ �ȴ�.
    }
}
