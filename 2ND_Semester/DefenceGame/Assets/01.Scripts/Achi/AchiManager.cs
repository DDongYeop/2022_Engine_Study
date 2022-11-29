using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiManager : MonoBehaviour
{
    [SerializeField] private AchievementCard achiCardPrefab;
    [SerializeField] private Transform acchiPanelContainer;
    [SerializeField] private Achievement[] achis;

    private void Start() 
    {
        LoadAchis();    
    }

    private void LoadAchis()
    {
        for (int i = 0; i < achis.Length; i++)
        {
            AchievementCard card = Instantiate(achiCardPrefab, acchiPanelContainer);
            card.SetUpAchi(achis[i]);
        }
    }
}
