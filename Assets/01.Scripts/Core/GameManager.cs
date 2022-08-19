using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _player;
    public Transform player { get => _player; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple Gamemanager is running");
        }
        Instance = this;
    }
}
