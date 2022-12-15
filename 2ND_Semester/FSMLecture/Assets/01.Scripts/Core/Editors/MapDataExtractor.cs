using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.IO;

public class MapDataExtractor
{
    [MenuItem("Tool/ExtractrMap")]
    public static void ExtractMapData()
    {
        GameObject tilemap = GameObject.Find("Tilemap");

        if (tilemap == null)
        {
            Debug.LogError("There is non TIlemap object in hierachy");
            return;
        }

        Tilemap collsion = tilemap.transform.Find("Collision").GetComponent<Tilemap>();
        collsion.CompressBounds(); //외곽 경계선 제거 

        BoundsInt bounds = collsion.cellBounds;

        using (StreamWriter writer = File.CreateText($"Assets/Resources/Map/{tilemap.name}.txt"))
        {
            writer.WriteLine(bounds.xMin);
            writer.WriteLine(bounds.xMax);
            writer.WriteLine(bounds.yMin);
            writer.WriteLine(bounds.yMax);

            //중간에 0은 존재하지만 존재하지 않음 그러기에 -1
            for (int y = bounds.yMax - 1; y >= bounds.yMin; y--)
            {
                for (int x = bounds.xMin; x <= bounds.xMin - 1; x++)
                {
                    Vector3Int tilepos = new Vector3Int(x, y, 0);
                    TileBase tile = collsion.GetTile(tilepos);

                    if (tile != null)
                        writer.Write("1");
                    else
                        writer.Write("0");
                    
                    // Window => \r \n, 
                    // Linux => \n, 
                    // MaxOS => \n
                    // 하지만 WriteLine는 OS상관이 없다  
                }
                writer.WriteLine("\n");
            }
        }
        // 위에처럼 using문 쓰고 {}하면 아래있는 Flush, Close 굳이 필요 없음 
        // writer.Flush();
        // writer.Close();
    }
}

//Editor 폴더 안에 있다면 빌드하면 다 날라감 
//컴파일 자체가 안 되기떄문에 
