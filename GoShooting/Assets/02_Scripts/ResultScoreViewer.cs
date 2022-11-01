using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textScore;
    private int _score = 000;

    private void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        _score = PlayerPrefs.GetInt("Score");
        textScore.text = "Result Score " + _score;
    }
}
