using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;

            for (int i = 0; i < 50; i++)
            {
                //Vector2 randPos = Random.insideUnitCircle; 
                float angle = Random.Range(0, 360f) * Mathf.Deg2Rad;
                Vector3 randPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));

                float factor = Random.Range(0.2f, 5f);
            }
        }
    }
}
