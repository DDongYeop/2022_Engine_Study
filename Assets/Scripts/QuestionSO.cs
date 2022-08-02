using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Qustion", fileName = " new Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)] 
    [SerializeField] string question = "Enter new question text here";
}
