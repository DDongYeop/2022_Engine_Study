using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] CannonSoundPlayer _cannonSound;
    [SerializeField] private Transform _cannonTrm;


    public Transform CannonTrm
    {
        get { return _cannonTrm; }
    }

    private CanonController _cannonController;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple GameManager instance is running");
        }
        Instance = this;

        _cannonController = _cannonTrm.GetComponent<CanonController>();
    }

    public void PlayExplosionSound()
    {
        _cannonSound.PlayExplosionSound();
    }

    public void BackToRigCam(float sec)
    {
        StartCoroutine(Delaysec(sec));
    }

    IEnumerator Delaysec(float sec)
    {
        yield return new WaitForSeconds(sec);
        CameraManager.Instance.SetRigCamActive();
        _cannonController.SetToIdle();
    }
}
