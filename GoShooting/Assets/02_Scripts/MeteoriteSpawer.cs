using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawer : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] GameObject alterLinePreFab;
    [SerializeField] GameObject meteoritePrefab;
    [SerializeField] float minSpawTime = 1f;
    [SerializeField] float maxSpawTime = 4f;

    void Start()
    {
        StartCoroutine("SpawnMeteorite");
    }

    IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            GameObject alterLineClone = Instantiate(alterLinePreFab, new Vector3(positionX, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);

            Destroy(alterLineClone);

            Vector3 meteoritePosition = new Vector3(positionX, stageData.LimitMax.y + 0.1f, 0);
            Instantiate(meteoritePrefab, meteoritePosition, Quaternion.identity);

            float spawnTime = Random.Range(minSpawTime, maxSpawTime);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
