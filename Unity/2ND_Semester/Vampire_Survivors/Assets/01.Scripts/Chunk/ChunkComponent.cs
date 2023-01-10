using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ChunkComponent : Icomponent
{
    private Subject<Chunk> chunkStream = new();
    private List<Chunk> chunks = new();
    public const int ChunkSize = 32;

    public ChunkComponent()
    {
    }

    public void UpdateState(GameState state)
    {
    }

    private void Init()
    {

    }

    private void PlayerChunkMoveEvent(Vector3Int index)
    {
        CreateChunk(index);

        chunkStream.OnNext(chunks[^1]);
    }

    private void CreateChunk(Vector3Int index)
    {
        var chunkMap = new int[ChunkSize, ChunkSize];

        var chunk = new Chunk(chunkMap, index);

        chunks.Add(chunk);
    }

    public void ChunkSubscibe(Action<Chunk> action)
    {
        chunkStream.Subscribe(action);
    }
}
