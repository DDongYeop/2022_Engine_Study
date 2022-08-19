using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _player;
    public Transform player { get => _player; }

    [SerializeField] private PoolingListSO _poolingList = null;
    [SerializeField] private Texture2D _cursorTexture = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple Gamemanager is running");
        }
        Instance = this;

        PoolManager.Instance = new PoolManager(transform);
        //Ǯ�Ŵ����� Ǯ���� �͵��� ������ִ� �۾��� �ؾ��ϴµ�

        CreatePool();
        SetCursorIcon();
    }

    private void CreatePool()
    {
        foreach (PoolingPair pp in _poolingList.list)
        {
            PoolManager.Instance.CreatePool(pp.prefab, pp.poolCount);
        }
    }

    private void SetCursorIcon() //Ŀ�� ����
    {
        Cursor.SetCursor(_cursorTexture, new Vector2(_cursorTexture.width / 2f, _cursorTexture.height / 2f), CursorMode.Auto);
    }
}
