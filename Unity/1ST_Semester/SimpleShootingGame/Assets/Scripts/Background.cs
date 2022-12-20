using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    MeshRenderer bgMatRenderer;
    public float scrollSpeed = 0.2f;
    void Start()
    {
        bgMatRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 direction = Vector2.up;
        bgMatRenderer.material.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
