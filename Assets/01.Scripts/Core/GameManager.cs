using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

        UIManager.Instance = new UIManager();

        _cannonController = _cannonTrm.GetComponent<CanonController>();
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
