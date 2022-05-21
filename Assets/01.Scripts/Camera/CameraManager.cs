using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera _cmRigcam;
    [SerializeField] private CinemachineVirtualCamera _cmCannonCam;

    private CinemachineBasicMultiChannelPerlin _cannonPerlin = null;

    private const int backProiority = 10;
    private const int frontProiority = 20;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple CameraManager instance is running");
        }
        Instance = this;
        _cannonPerlin = _cmCannonCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCam(float intensity, float time)
    {
        StartCoroutine(ShakeCamCorutine(intensity, time));
    }

    IEnumerator ShakeCamCorutine(float intensity, float endTime)
    {
        _cannonPerlin.m_AmplitudeGain = intensity;

        float currentTime = 0f;
        while(currentTime < endTime)
        {
            yield return null;
            _cannonPerlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, currentTime / endTime);
            currentTime += Time.deltaTime;
        }
        _cannonPerlin.m_AmplitudeGain = 0;
    }

    public void SetCannonCamActive()
    {
        _cmCannonCam.Priority = frontProiority;
        _cmRigcam.Priority = backProiority;
    }

    public void SetRigCamActive()
    {
        _cmRigcam.Priority = frontProiority;
        _cmCannonCam.Priority = backProiority;
    }
}
