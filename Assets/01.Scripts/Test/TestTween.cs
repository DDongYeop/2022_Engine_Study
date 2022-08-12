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

            //UI�ʿ����� ���� ����
            seq.Append(transform.DOMove(woldPos, 1f).SetEase(Ease.Linear));
            //seq.Join() //����ð� �������� ����
            seq.Append(transform.DOScale(2, .5f).SetLoops(2, LoopType.Yoyo));
            seq.AppendCallback(GGM);

            //delegate, TO
            //Action, �͸��Լ�, ����

            // sha256, bcrypt, AES (�����Ѱ�)
        }
    }

    public void GGM()
    {
        Debug.Log("���� ����");
    }
}


/* 
 * (�ѱ���) ��Ʈ�� �� �����ص� ��α�
 * https://m.blog.naver.com/PostList.naver?blogId=hana100494
 */
