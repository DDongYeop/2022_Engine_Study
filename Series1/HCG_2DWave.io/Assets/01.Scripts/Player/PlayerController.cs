using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StageController _stageController;
    [SerializeField] private GameObject _playerDieEffect;
    private Movement2D _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        if (_stageController.isGameOver == true)
            return;

        _movement.MoveToX();

        if (Input.GetMouseButton(0))
            _movement.MoveToY();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Item"))
        {
            _stageController.IncreaseScore(1);
            collision.GetComponent<Item>().Exit();
        }

        else if (collision.tag.Equals("Obstacle"))
        {
            Instantiate(_playerDieEffect, transform.position, Quaternion.identity);
            Destroy(GetComponent<Rigidbody2D>());
            _stageController.GameOver();
        }
    }
}
