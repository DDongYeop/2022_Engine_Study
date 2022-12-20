using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneratorRandomPositionUtil : MonoBehaviour
{
    public GameObject objectPrefab;
    public float radius = 0.2f;

    protected Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }
    protected Quaternion Random2DRoatation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public void CreateObject()
    {
        Vector2 postion = GetRandomPosition();
        GameObject impactObject = GetObject();
        impactObject.transform.position = postion;
        impactObject.transform.rotation = Random2DRoatation();
    }

    private GameObject GetObject()
    {
        return Instantiate(objectPrefab);
    }
    
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
