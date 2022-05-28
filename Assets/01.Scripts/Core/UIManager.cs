using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class UIManager  
{
    public static UIManager Instance = null;

    private RectTransform _canvasTrm;
    private TextMeshProUGUI _noticeMegTxt;

    public UIManager()
    {
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _noticeMegTxt = _canvasTrm.Find("BottomPanel/NoticeMessageText").GetComponent<TextMeshProUGUI>();
        _noticeMegTxt.SetText("");
    }

    public void ShowTextMessage(string text)
    {
        _noticeMegTxt.SetText(text);
        _noticeMegTxt.color = Color.white;
        _noticeMegTxt.DOFade(0.2f, 1f).SetLoops(-1, LoopType.Yoyo);
    }    

    public void HideTextMessage(Action NextAction)
    {

    }
}
