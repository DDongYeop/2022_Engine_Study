using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 5;
    Vector3 dir;

    private void Start()
    {
        int randValue = Random.Range(0, 10);  // 0 ~ 9
        if(randValue < 3) // 30% 확률, 플래이어 방향으로 가라
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else // 아래로 가라 
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        sm.SetScore(sm.GetScore()+1);
        GameObject Explosion = Instantiate(explosion);
        Explosion.transform.position = transform.position;
        Destroy(gameObject);
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
        
    }
}
