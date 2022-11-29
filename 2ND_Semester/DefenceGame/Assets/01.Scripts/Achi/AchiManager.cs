using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiManager : Singleton<AchiManager>
{
    public static Action<Achievement> OnAchiUnlocked;

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

    public void AddProgress(string achiID, int amount)
    {
        Achievement achiWanted = AchiExists(achiID);
        if (achiWanted != null)
        {
            achiWanted.AddProgress(amount);
        }
    }

    public Achievement AchiExists(string achiID)
    {
        for (int i = 0; i < achis.Length; i++)
        {
            if (achis[i].ID == achiID)
                return achis[i];
        }

        return null;
    }
}
