using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool _isStep = false;

    private void OnEnable()
    {
        _isStep = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
                obstacles[i].SetActive(true);
            else
                obstacles[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (transform.position.x <= -15f)
            PoolManager.Instance.Push(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && _isStep == false)
        {
            _isStep = true;
            GameManager.instance.AddScore(1);
        }
    }
}
