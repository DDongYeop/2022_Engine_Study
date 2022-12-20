using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dlsslve : MonoBehaviour
{
    [SerializeField] bool isDissolve = false;

    private float _fade = 1;

    private Material _mat;

    private void Awake()
    {
        _mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if(isDissolve)
        {
            _fade -= Time.unscaledDeltaTime;

            if (_fade <= 0)
            {
                _fade = 0;
                isDissolve = false;
            }

            _mat.SetFloat("_Fade", _fade);
        }

        else
        {
            _fade += Time.unscaledDeltaTime;

            if (_fade >= 1)
            {
                _fade = 1;

                isDissolve = true;
            }
            _mat.SetFloat("_Fade", _fade);
        }
    }
}
