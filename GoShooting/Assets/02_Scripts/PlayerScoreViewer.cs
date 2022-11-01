using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    
    TextMeshProUGUI textScore;

    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textScore.text = "Score " + playerController.Score;
    }
}
