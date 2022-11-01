using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroy : MonoBehaviour
{
    [SerializeField] StageData stageData;
    float destroyWeight = 2f;
    ObjectPooler bulletPooler;
    ObjectPooler enemyPooler;
     
    private void Start()
    {
        bulletPooler = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectPooler>();
        enemyPooler = GameObject.Find("EnemySpwaner").GetComponent<ObjectPooler>();

    }

    private void LateUpdate()
    {
        if(transform.position.x > stageData.LimitMax.x + destroyWeight || 
           transform.position.x < stageData.LimitMin.x - destroyWeight ||
           transform.position.y > stageData.LimitMax.y + destroyWeight || 
           transform.position.y < stageData.LimitMin.y - destroyWeight )
        {
            if(gameObject.tag == "Playerbullet")
            {
                bulletPooler.ReturnObject(gameObject);
            }
            else if(gameObject.tag == "Enemy")
            {
                enemyPooler.ReturnObject(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
