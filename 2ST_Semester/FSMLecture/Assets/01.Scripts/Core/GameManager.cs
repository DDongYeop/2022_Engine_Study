using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Transform _playerTrm;
    public Transform PlayerTrm => _playerTrm;

    public static GameManager Instance;

    private void Awake() 
    {
        _playerTrm = GameObject.Find("Player").transform;

        // 미래의 나를 믿지 않기에 이걸 사용
        if (Instance != null)
            Debug.LogError("Multiple Gamemanager is running!");

        Instance = this;
    }
}
