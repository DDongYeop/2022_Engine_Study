using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        _movement.MoveToX();

        if (Input.GetMouseButton(0))
            _movement.MoveToY();
    }
}
