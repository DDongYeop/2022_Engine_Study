using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera _cmRigcam;
    private CinemachineVirtualCamera _cmCannonCam;
    private CinemachineVirtualCamera _cmActionCam;

    private CamRig _camRig;

    private const int backPriority = 10;
    private const int frontPriority = 15;
    //const = Á¤!»ó!¼ö!
    private CinemachineBasicMultiChannelPerlin _cannonPerilin = null;
    private CinemachineBasicMultiChannelPerlin _actionPerilin = null;

    public static CameraManager Instance;

    private CinemachineVirtualCamera _activeVCam = null;
    private CinemachineBasicMultiChannelPerlin _activePerlin = null;


    // Start is called before the first frame update



    public void Init()
    {
        _cmRigcam = GameObject.Find("CMVcamRig").GetComponent<CinemachineVirtualCamera>();
        _cmActionCam = GameObject.Find("CMVcamAction").GetComponent<CinemachineVirtualCamera>();
        _cmCannonCam = GameObject.Find("CMVcamCannon").GetComponent<CinemachineVirtualCamera>();

        _cannonPerilin = _cmCannonCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _actionPerilin = _cmActionCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _camRig = GameObject.Find("CamRig").GetComponent<CamRig>();
    }

    public void ShakeCam(float intensity, float sec)
    {
        if (_activeVCam == null || _activePerlin == null) return;
        StopAllCoroutines();
        StartCoroutine(ShakeCamCoroutine(intensity, sec));
    }

    IEnumerator ShakeCamCoroutine(float Intensity, float endTime)
    {
        _activePerlin.m_AmplitudeGain = Intensity;
        float currentTime = 0f;
        while (currentTime < endTime)
        {
            yield return null;
            if (_activePerlin == null) break;
            _activePerlin.m_AmplitudeGain = Mathf.Lerp(Intensity, 0, currentTime / endTime);
            currentTime += Time.deltaTime;
        }
        if (_activePerlin != null)
            _activePerlin.m_AmplitudeGain = 0;
    }
    public void SetConfiner(PolygonCollider2D confiner)
    {
        //_cmCannonCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner;
        _cmActionCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner;
        _cmRigcam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner;
        _camRig.Confiner = confiner;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCannonCamActive()
    {
        _cmCannonCam.Priority = frontPriority;
        _cmRigcam.Priority = backPriority;
        _cmActionCam.Priority = backPriority;

        _activePerlin = _cannonPerilin;
        _activeVCam = _cmCannonCam;
    }

    public void SetRigCamActive()
    {
        _cmRigcam.Priority = frontPriority;
        _cmCannonCam.Priority = backPriority;
        _cmActionCam.Priority = backPriority;

        _activePerlin = null;
        _activeVCam = _cmRigcam;

    }

    public void SetActionCamActive(Transform followTarget)
    {
        _cmActionCam.m_Follow = followTarget;
        _cmRigcam.Priority = backPriority;
        _cmCannonCam.Priority = backPriority;
        _cmActionCam.Priority = frontPriority;

        _activePerlin = _actionPerilin;
        _activeVCam = _cmActionCam;
    }
}