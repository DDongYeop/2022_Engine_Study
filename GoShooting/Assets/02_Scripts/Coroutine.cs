using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour // 사용 안함
{
    public GameObject playerbullet;

    void Start()
    {
        StartCoroutine("Fire");
    }


    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetButton("Fire1"));
            Instantiate(playerbullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.25f);
        }
    }
}
