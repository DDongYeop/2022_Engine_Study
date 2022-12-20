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
        currentScoreTxt.text = "현재점수 : " + currentScore;
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreTxt.text = "최고점수 : " + bestScore;
    }
    public void BtnRestart() //스트링으로 변수선언하고
    {
        SceneManager.LoadScene("PlayScene"); //선언한거 쓰고, on click에서 정해줘도 된다.
    }
}
