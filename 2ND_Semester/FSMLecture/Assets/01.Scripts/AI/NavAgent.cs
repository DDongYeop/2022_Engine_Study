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

    private void Awake() 
    {
        _openList = new PriorityQueue<Node>();
        _closeList = new List<Node>();
    }

    private void Start() 
    {
        Vector3Int cellPos = _tilemap.WorldToCell(transform.position);
        _currentPosition = cellPos;
        transform.position = _tilemap.GetCellCenterWorld(cellPos);
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mPos = Input.mousePosition;
            mPos.z = 0;
            Vector3 world = Camera.main.ScreenToWorldPoint(mPos);
            Vector3Int cellPos = _tilemap.WorldToCell(world); //이걸로 월드를 타일 맵 포지션으로 변경 

            Debug.Log(cellPos);
            //이 cellpos가 진짜 갈 수 있는데인지 체크해야함
            
            _destination = cellPos;
            CalcRoute();
            PrintRoute();
        }
    }

    private void PrintRoute() //계산한 경로를 디버그로 찍어본다. 
    {

    }

    private void CalcRoute()
    {
        _openList.Clear();
        _closeList.Clear();

        _openList.Push(new Node 
        { 
            pos = _currentPosition, 
            _parnet = null, G = 0, 
            F = CalcH(_currentPosition)
        });

        bool result = false; //이건 갈 수 있는 곳인가?
        int cnt = 0; //안전코드
        while (_openList.Count > 0)
        {
            Node n = _openList.Pop(); //가장 가깝게 갈 수 있는 녀석을 뽑아온다

        }
    }

    private void FindOpenList()
    {
        
    }

    private float CalcH(Vector3Int pos)
    {
        //F = G + H
        Vector3Int distance = _destination - pos;
        return distance.magnitude;
    }
}
