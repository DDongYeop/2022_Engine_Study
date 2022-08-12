using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestTween : MonoBehaviour
{
    private string a = "Hello world";

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 woldPos = Camera.main.ScreenToWorldPoint(mousePos);
            woldPos.z = 0;

            Sequence seq = DOTween.Sequence();

            //UI쪽에서도 많이 쓴다
            seq.Append(transform.DOMove(woldPos, 1f).SetEase(Ease.Linear));
            //seq.Join() //실행시간 위에꺼랑 같이
            seq.Append(transform.DOScale(2, .5f).SetLoops(2, LoopType.Yoyo));
            seq.AppendCallback(GGM);

            //delegate, TO
            //Action, 익명함수, 람다

            // sha256, bcrypt, AES (괴랄한거)
        }
    }

    public void GGM()
    {
        Debug.Log("동작 종료");
    }
}


/* 
 * (한국어) 다트윈 잘 설명해둔 블로그
 * https://m.blog.naver.com/PostList.naver?blogId=hana100494
 */
