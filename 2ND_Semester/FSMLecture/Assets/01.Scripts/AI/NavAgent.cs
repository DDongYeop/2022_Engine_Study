using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NavAgent : MonoBehaviour
{
    private PriorityQueue<Node> _openList;
    private List<Node> _closeList;

    private List<Vector3Int> _routePath;

    public float speed = 5f;
    public bool cornerCheck = false;

    private Vector3Int _currentPosition; //현재 타일 위치
    private Vector3Int _destination; //목표 타일 위치

    [SerializeField] private Tilemap _tilemap;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mPos = Input.mousePosition;
            mPos.z = 0;
            Vector3 world = Camera.main.ScreenToWorldPoint(mPos);
            Vector3Int cellPos = _tilemap.WorldToCell(world); //이걸로 월드를 타일 맵 포지션으로 변경 

            Debug.Log(cellPos);
        }
    }
}
