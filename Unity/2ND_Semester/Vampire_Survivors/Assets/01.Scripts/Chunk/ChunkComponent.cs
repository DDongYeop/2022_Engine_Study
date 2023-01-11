using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Random = System.Random;

public class ChunkComponent : Icomponent
{
    public const int ChunkSize = 32;

    private const int Seed = 1;

    private Subject<Chunk> chunkStream = new();

    private List<Chunk> chunks = new();

    private Random random;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                Init();
                break;
        }
    }

    private void Init()
    {
        GameManager.Instance.GetGameComponent<PlayerComponent>().PlayerChunkMoveSubscribe(PlayerChunkMoveEvent);

        random = new Random(Seed.GetHashCode());
    }

    private void PlayerChunkMoveEvent(Vector3Int index)
    {
        CreateChunk(index);

        for (int i = 0; i < chunks.Count; i++)
        {
            chunkStream.OnNext(chunks[i]);
        }
    }

    private void CreateChunk(Vector3Int index)
    {
        for (int i = index.x - 1; i <= index.x + 1; i++)
        {
            for (int j = index.y - 1; j <= index.y + 1; j++)
            {
                var chunkMap = new int[ChunkSize, ChunkSize];
                var chunkIndex = new Vector3Int(i, j);
                RandomFillMp(chunkMap);

                for (int z = 0; z < 10; z++)
                    SmoothMap(chunkMap);

                var chunk = new Chunk(chunkMap, chunkIndex);

                if (!IsChunkExist(chunk))
                    chunks.Add(chunk);
            }
        }
    }

    private void SmoothMap(int[,] map)
    {
        for (int x = 0; x < ChunkSize; x++)
        {
            for (int y = 0; y < ChunkSize; y++)
            {
                var neighbourWallCount = GetSurroundingGrassCount(map, x, y); 

                if (neighbourWallCount > 4)
                {
                    map[x, y] = 0;
                }
                else if(neighbourWallCount < 4)
                {
                    map[x, y] = 1;
                }
            }
        }
    }

    private int GetSurroundingGrassCount(int[,] map, int gridX, int gridY)
    {
        var grassCount = 0;

        for (int i = gridX - 1; i <= gridX + 1; i++)
        {
            for (int j = gridY - 1; j <= gridY + 1; j++)
            {
                if (i >= 0 && i < ChunkSize && j >= 0 && j < ChunkSize)
                {
                    if (i != gridX || j != gridY)
                    {
                        grassCount += map[i, j] == 0 ? 1 : 0;
                    }
                }
                else
                {
                    grassCount++;
                }
            }
        }

        return grassCount;
    }

    private void RandomFillMp(int[,] map)
    {
        for (var x = 0; x < ChunkSize; x++)
        {
            for (var y = 0; y < ChunkSize; y++)
            {
                if (x == 0 || x == ChunkSize - 1 || y == 0 || y == ChunkSize - 1)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = random.Next(0, 100) < 50 ? 0 : 1;
                }
            }
        }
    }

    private bool IsChunkExist(Chunk target)
    {
        return chunks.Any(chunk => chunk.index.Equals(target.index));
    }

    public void ChunkSubscribe(Action<Chunk> action)
    {
        chunkStream.Subscribe(action);
    }
}
