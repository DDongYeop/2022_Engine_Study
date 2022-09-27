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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Item"))
            Destroy(collision.gameObject);
        else if (collision.tag.Equals("Obstacle"))
            print("Game over");
    }
}
