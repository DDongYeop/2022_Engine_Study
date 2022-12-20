using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonPanel : MonoBehaviour
{
    private Image _fillImage;
    private TextMeshProUGUI _textAngle;

    private void Awake()
    {
        _fillImage = transform.Find("GaugeMask/ImageMask").GetComponent<Image>();
        _textAngle = transform.Find("TextAngle").GetComponent<TextMeshProUGUI>();
    }

    public void SetPowerGauge(float powerNormal)
    {
        _fillImage.fillAmount = powerNormal;
    }

    public void SetTextAngle(float angle)
    {
        _textAngle.SetText($"{angle.ToString("F2")} 도"); //여기에 angle을 표기해서 넣어야한다
    }
}
