using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float _width;

    private void Awake()
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        _width = backGroundCollider.size.x;
    }

    private void Update()
    {
        if (transform.position.x <= -_width)
        {
            Repositiooning();
        }
    }

    private void Repositiooning()
    {
        Vector2 offset = new Vector2(_width * 2, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
