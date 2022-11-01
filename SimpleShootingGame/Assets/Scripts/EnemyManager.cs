using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory;


    float minTime = 1f;
    float maxTime = 5f;
    float currentTime = 0;
    float creatTime;

    private void Start()
    {
        creatTime = Random.Range(minTime, maxTime);
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= creatTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0;
        }
    }
}
