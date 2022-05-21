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

    private void Awake()
    {
        Instance = this;
    }

    public void PlayExplosionSound()
    {
        _cannonSound.PlayExplosionSound();
    }
}
