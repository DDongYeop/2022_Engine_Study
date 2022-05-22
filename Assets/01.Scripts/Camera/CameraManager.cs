using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera _cmRigcam;
    [SerializeField] private CinemachineVirtualCamera _cmCannonCam;
    [SerializeField] private CinemachineVirtualCamera _cmActionCam;

    private CinemachineBasicMultiChannelPerlin _cannonPerlin = null;
    private CinemachineBasicMultiChannelPerlin _actionPerlin = null;

    private const int backProiority = 10;
    private const int frontProiority = 20;

    private CinemachineVirtualCamera _activeVCam = null;
    private CinemachineBasicMultiChannelPerlin _activePerlin = null;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple CameraManager instance is running");
        }
        Instance = this;
        _cannonPerlin = _cmCannonCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _activePerlin = _cmActionCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void ShakeCam(float intensity, float time)
    {
        if (_activeVCam == null || _activePerlin == null) return;
        StopAllCoroutines(); //현재구동중인 모든 코루틴을 제거하고 수행
        StartCoroutine(ShakeCamCorutine(intensity, time));
    }

    IEnumerator ShakeCamCorutine(float intensity, float endTime)
    {
        _activePerlin.m_AmplitudeGain = intensity;

        float currentTime = 0f;
        while(currentTime < endTime)
        {
            yield return null;
            _activePerlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, currentTime / endTime);
            currentTime += Time.deltaTime;
        }
        _activePerlin.m_AmplitudeGain = 0;
    }

    public void SetCannonCamActive()
    {
        _cmCannonCam.Priority = frontProiority;
        _cmRigcam.Priority = backProiority;
        _cmActionCam.Priority = backProiority;

        _activePerlin = _cannonPerlin;
        _activeVCam = _cmCannonCam;
    }

    public void SetRigCamActive()
    {
        _cmRigcam.Priority = frontProiority;
        _cmCannonCam.Priority = backProiority;
        _cmActionCam.Priority = backProiority;

        _activePerlin = null;
        _activeVCam = _cmRigcam;
    }

    public void SetActionCamActive(Transform flollowTarget)
    {
        _cmActionCam.m_Follow = flollowTarget;

        _cmRigcam.Priority = backProiority;
        _cmCannonCam.Priority = backProiority;
        _cmActionCam.Priority = frontProiority;

        _activePerlin = _actionPerlin;
        _activeVCam = _cmActionCam;
    }
}
