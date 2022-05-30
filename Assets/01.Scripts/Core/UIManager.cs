using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class UIManager  
{
    public static UIManager Instance = null;

    private RectTransform _canvasTrm;
    private TextMeshProUGUI _noticeMegTxt;
    private RectTransform _msgTrm;
    private TextMeshProUGUI _boxCountText;

    private RectTransform _innerPopupWindow;
    private RectTransform _outerPopupPanel;

    private Vector3 _initAnchorPos; //초기 앵커 위치 가져오는 변수

    public UIManager()
    {
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _noticeMegTxt = _canvasTrm.Find("BottomPanel/NoticeMessageText").GetComponent<TextMeshProUGUI>();
        _noticeMegTxt.SetText("");
        _msgTrm = _noticeMegTxt.GetComponent<RectTransform>();
        _initAnchorPos = _msgTrm.anchoredPosition; //초기 앵커위치 저장

        _boxCountText = _canvasTrm.Find("TopPanel/BoxCountPanel/BoxCountText").GetComponent<TextMeshProUGUI>();

        _outerPopupPanel = _canvasTrm.Find("PopupPanel").GetComponent<RectTransform>();
        _innerPopupWindow = _outerPopupPanel.Find("InnerPopupImage").GetComponent<RectTransform>();
    }

    public void ShowTextMessage(string text)
    {
        _msgTrm.anchoredPosition = _initAnchorPos; //띄울때 초기 앵커위치로 복귀
        _noticeMegTxt.SetText(text);
        _noticeMegTxt.color = Color.white;
        _noticeMegTxt.DOFade(0.2f, 1f).SetLoops(-1, LoopType.Yoyo);
    }    

    public void HideTextMessage(Action NextAction)
    {
        _noticeMegTxt.DOKill();//기존에 재생되던 애니메이션을 전부 죽이고

        Sequence seq = DOTween.Sequence();
        Vector3 targetPos = _initAnchorPos + new Vector3(970f, 0, 0);
        targetPos.x += 970f;
        seq.Append(_msgTrm.DOAnchorPos(targetPos, 0.4f));
        seq.Join(_noticeMegTxt.DOFade(0, 0.4f));

        seq.OnComplete(() =>
        {
            _noticeMegTxt.SetText("");
            NextAction?.Invoke();
        });
    }

    public void SetBoxScore(int currentBoxCount, int totalBoxCount, Action CallBack = null)
    {
        _boxCountText.SetText($"{currentBoxCount} / {totalBoxCount}");
        if(CallBack != null)
            _boxCountText.rectTransform.DOShakeAnchorPos(0.3f, 25, 25).SetUpdate(true).OnComplete(() => CallBack());
    }

    public void ShowResultWindow(int startCnt)
    {
        Image img = _outerPopupPanel.GetComponent<Image>();
        Sequence seq = DOTween.Sequence();
        seq.Append(img.DOFade(0.8f, 0.3f));
        seq.Append(_innerPopupWindow.DOAnchorPos(Vector2.zero - new Vector2(0, 70f), 0.3f));
        seq.Append(_innerPopupWindow.DOAnchorPos(Vector2.zero + new Vector2(0, 30f), 0.2f));
        seq.Append(_innerPopupWindow.DOAnchorPos(Vector2.zero, 0.2f));

        List<RectTransform> childRect = new List<RectTransform>();
        _innerPopupWindow.Find("GoldStarPanel").GetComponentsInChildren<RectTransform>(childRect);
        childRect.RemoveAt(0); //맨 첫번째 애는 지워준다. 부모끼리

        for(int i = 0; i < startCnt; i++)
        {
            Image starImage = childRect[i].GetComponent<Image>();
            seq.Append(starImage.DOFade(1f, 0.3f));
            seq.Join(childRect[i].DORotate(new Vector3(0, 720f, 0), 0.3f, RotateMode.FastBeyond360));
            seq.Join(childRect[i].DOScale(Vector3.one, 0.3f) );
        }
    }

    public void CloseResultWindow()
    {
        Image img = _outerPopupPanel.GetComponent<Image>();
        Sequence seq = DOTween.Sequence();
        seq.Append(_innerPopupWindow.DOAnchorPos(Vector2.zero + new Vector2(0, 1000f), 0.3f));
        seq.Append(img.DOFade(0f, 0.3f));
    }
}
