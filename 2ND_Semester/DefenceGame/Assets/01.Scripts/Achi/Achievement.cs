using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievenment")]
public class Achievement : ScriptableObject
{
    public string ID; //도전과제 ID
    public string Title; //도전과제 이름
    public int ProgressToUnlock; // 0/50 현재 달성 정도
    public int GoalReward; //보상
    public Sprite Sprite; //스프라이트
}
