using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _lives = 10;

    private void ReduceLives()
    {
        _lives--;
    }

    private void OnEnable() //게임오브젝트가 활성화 될떄마다
    {
        Enemy.OnEndReached += ReduceLives;
    }

    private void OnDisable() //게임오브젝트가 비활성화 될떄마다
    {
        Enemy.OnEndReached -= ReduceLives;
    }
}
