using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour // 사용 안함
{
    public GameObject playerbullet;

    void Start()
    {
        StartCoroutine("Fire"); //"Fire" 대신 Fire()를 사용 가능
        //메서드 사용시 Fire(playerbullet) << 이런식으로 해야댐 
        //StartCoroutine("Fire2");

        //StopCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(playerbullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    /*IEnumerator Fire2()
    {
        print("ㅂ");
        yield return new WaitForSeconds(2f);
        print("ㅁ");
    }*/
}

/* Fire와 Fire1가 있다면 Fire가 실행되고 Fire1이 실행 되어야 하지만 코루틴은 호출한 시점에 동기화한다.
 * 정리하면 코루틴은 지연도 하지만 다른 메서드도 할 수 있도록 넘겨준다 그래서 무한 루프를 해도 안 터진다*/