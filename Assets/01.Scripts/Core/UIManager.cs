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
    private RectTransform _msgTrm;
    private TextMeshProUGUI _boxCountText;

    private Vector3 _initAnchorPos; //�ʱ� ��Ŀ ��ġ �������� ����

    public UIManager()
    {
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _noticeMegTxt = _canvasTrm.Find("BottomPanel/NoticeMessageText").GetComponent<TextMeshProUGUI>();
        _noticeMegTxt.SetText("");
        _msgTrm = _noticeMegTxt.GetComponent<RectTransform>();
        _initAnchorPos = _msgTrm.anchoredPosition; //�ʱ� ��Ŀ��ġ ����

        _boxCountText = _canvasTrm.Find("TopPanel/BoxCountPanel/BoxCountText").GetComponent<TextMeshProUGUI>();
    }

    public void ShowTextMessage(string text)
    {
        _msgTrm.anchoredPosition = _initAnchorPos; //��ﶧ �ʱ� ��Ŀ��ġ�� ����
        _noticeMegTxt.SetText(text);
        _noticeMegTxt.color = Color.white;
        _noticeMegTxt.DOFade(0.2f, 1f).SetLoops(-1, LoopType.Yoyo);
    }    

    public void HideTextMessage(Action NextAction)
    {
        _noticeMegTxt.DOKill();//������ ����Ǵ� �ִϸ��̼��� ���� ���̰�

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

    public void SetBoxScore(int currentBoxCount, int totalBoxCount, Action CallBack)
    {
        _boxCountText.SetText($"{currentBoxCount} / {totalBoxCount}");
        _boxCountText.rectTransform.DOShakeAnchorPos(0.3f, 25, 25).SetUpdate(true).OnComplete(() => CallBack());
    }
}
