using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] int scorePoint = 100;
    [SerializeField] GameObject explpsonPrefab;
    
    PlayerController playerController;
    ObjectPooler enemyPooler;
    
    private void Awake()
    {
        enemyPooler = GameObject.Find("EnemySpwaner").GetComponent<ObjectPooler>();

        //세개 다 똑같다고 생각하면 됨
        playerController = FindObjectOfType<PlayerController>();
        //게임 오브잭트 이름으로 찾기playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //playerController = GameObject.FindGameObjectsWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamge(damage);
            Destroy(gameObject);
            Die();
        }
    }

    public void Die()
    {
        playerController.Score += scorePoint;
        GameObject clone = Instantiate(explpsonPrefab, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        enemyPooler.ReturnObject(gameObject);
        Destroy(clone.gameObject, 1f);
    }
}
