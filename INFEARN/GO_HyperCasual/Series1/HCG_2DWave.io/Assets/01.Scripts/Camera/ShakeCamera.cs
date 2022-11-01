using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private static ShakeCamera instance;

    public static ShakeCamera Instance => instance;

    private float _shakeTime;
    private float _shakeIntensity;

    public ShakeCamera()
    {
        instance = this;
    }

    public void OnShakeCamera(float shakeTime = 1f, float shakeIntensity = .1f)
    {
        this._shakeTime = shakeTime;
        this._shakeIntensity = shakeIntensity;

        StopCoroutine(SHakeByRotation());
        StartCoroutine(SHakeByRotation());
    }

    private IEnumerator SHakeByRotation()
    {
        Vector3 startRotation = transform.eulerAngles;

        float power = 10f;

        while (_shakeTime > 0)
        {
            float x = 0;
            float y = 0;
            float z = Random.RandomRange(-1, 1);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * _shakeIntensity * power);

            _shakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.rotation = Quaternion.Euler(startRotation);
    }
}
