using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager
{
    private Tilemap _mainMap;
    private Tilemap _collisionMap;

    public static MapManager Instance;

    public MapManager(Transform tilemapObject)
    {
        _collisionMap = tilemapObject.Find("Collision").GetComponent<Tilemap>();
        _mainMap = tilemapObject.Find("Background").GetComponent<Tilemap>();
        _mainMap.CompressBounds(); //외곽 테두리를 딱맞게 조여주는거야 
    }

    //이 포지션이 이동 가능한 공간인가?
    public bool CanMove(Vector3Int pos)
    {
        BoundsInt mapBound = _mainMap.cellBounds;
        if (pos.x < mapBound.xMin || pos.x > mapBound.xMax || pos.y < mapBound.yMin || pos.y > mapBound.yMax)
            return false;

        return _collisionMap.GetTile(pos) == null;
    }

    public Vector3Int GetTilePos(Vector3 worldPos)
    {
        return _mainMap.WorldToCell(worldPos);
    }

    public Vector3 GetWorldPos(Vector3Int cellPos)
    {
        return _mainMap.GetCellCenterWorld(cellPos);
    }
}
