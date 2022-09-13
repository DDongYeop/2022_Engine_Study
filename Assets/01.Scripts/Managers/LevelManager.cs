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

    private void OnEnable() //���ӿ�����Ʈ�� Ȱ��ȭ �ɋ�����
    {
        Enemy.OnEndReached += ReduceLives;
    }

    private void OnDisable() //���ӿ�����Ʈ�� ��Ȱ��ȭ �ɋ�����
    {
        Enemy.OnEndReached -= ReduceLives;
    }
}
