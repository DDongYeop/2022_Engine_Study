using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance { get; private set; }

    [SerializeField] private RectTransform _canvasRectTransform;

    private RectTransform _rectTransform;
    private TextMeshProUGUI _textMeshPro;
    private RectTransform _backGroundRectTransform;

    private void Awake()
    {
        Instance = this;

        _rectTransform = GetComponent<RectTransform>();
        _textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        _backGroundRectTransform = transform.Find("BackGround").GetComponent<RectTransform>();

        Hide();
    }

    private void Update()
    {
        Vector2 anchoredPosition = _rectTransform.anchoredPosition = Input.mousePosition / _canvasRectTransform.localScale.x;

        /*if (anchoredPosition.x + _backGroundRectTransform.rect.width > _rectTransform.rect.width)
            anchoredPosition.x = _canvasRectTransform.rect.width - _backGroundRectTransform.rect.width;
        if (anchoredPosition.y + _backGroundRectTransform.rect.height > _rectTransform.rect.height)
            anchoredPosition.y = _canvasRectTransform.rect.height - _backGroundRectTransform.rect.height;*/

        _rectTransform.anchoredPosition = anchoredPosition;
    }

    private void SetText(string tolltipText)
    {
        _textMeshPro.SetText(tolltipText);
        _textMeshPro.ForceMeshUpdate();

        Vector2 textSIze = _textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(8, 8);
        _backGroundRectTransform.sizeDelta = textSIze + padding;
    }

    public void Show(string tolltipText)
    {
        gameObject.SetActive(true);
        SetText(tolltipText);
    }

    public void Hide()
    {
        gameObject?.SetActive(false);
    }
}
