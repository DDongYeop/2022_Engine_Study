using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private float _speed = 10f;

    private void Update()
    {
        if (GameManager.instance.IsGameOver == false)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
