using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileComponent : MonoBehaviour, Icomponent
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tilebase;

    private int size = 64;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.STANDBY:
                Reset();
                Generate();
                break;
        }
    }

    private void Generate()
    {
        var tileStartPosition = -new Vector3Int(size / 2, size / 2);

        for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
            {
                var tilePostion = new Vector3Int((int)(tileStartPosition.x + i), (int)(tileStartPosition.y + j));
                tilemap.SetTile(tilePostion, tilebase);
            }
    }

    private void Reset() 
    {
        tilemap.ClearAllTiles();
    }
}
