using System.Collections.Generic;
using UnityEngine;

public class UIComponent : Icomponent
{
    private List<UIScreen> uIScreens = new();

    public UIComponent()
    {
        uIScreens.Add(GameObject.Find("Init Screen").GetComponent<UIScreen>());
        uIScreens.Add(GameObject.Find("Standby Screen").GetComponent<UIScreen>());
        uIScreens.Add(GameObject.Find("Running Screen").GetComponent<UIScreen>());
        uIScreens.Add(GameObject.Find("Result Screen").GetComponent<UIScreen>());
    }

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                InitAllScreen();
                CloseAllScreen();
                break;
            default:
                ActiveScreen(state);
                break;
        }
    }
    
    private void ActiveScreen(GameState state)
    {
        CloseAllScreen();

        for (int i = 0; i < uIScreens.Count; i++)
        {
            if (uIScreens[i].state == state)
                uIScreens[i].UpdateScreenState(true);
        }
    }

    private void CloseAllScreen()
    {
        foreach (var screen in uIScreens)
        {
            screen.UpdateScreenState(false);
        }
    }

    private void InitAllScreen()
    {
        foreach (var screen in uIScreens)
        {
            screen.Init();
        }
    }
}