using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private float _fadeTIme;
    private TextMeshProUGUI _textFade;

    private void Awake()
    {
        _textFade = GetComponent<TextMeshProUGUI>();

        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));
            yield return StartCoroutine(Fade(0, 1));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / _fadeTIme;

            Color color = _textFade.color;
            color.a = Mathf.Lerp(start, end, percent);
            _textFade.color = color;

            yield return null;
        }
    }
}
