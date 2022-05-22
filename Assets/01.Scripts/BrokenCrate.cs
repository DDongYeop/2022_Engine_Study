using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCrate : MonoBehaviour
{
    private Vector3[] _initPosition;
    private Rigidbody2D[] _childRigidArr;

    private void Awake()
    {
        _initPosition = new Vector3[transform.childCount]; //�ڽ��� ������ŭ �迭 ����
        _childRigidArr = new Rigidbody2D[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            _initPosition[i] = child.localPosition;//�� ���÷� ���� �ؾ���
            //�� �׷��� ���� ��ǥ�� �����Ǿ� ������ ������ ó�� ��ġ�� ���ư�����
            _childRigidArr[i] = child.GetComponent<Rigidbody2D>();
        }
    }

    public void AddForce(Vector2 dir, float power)
    {
        foreach(Rigidbody2D rigid in _childRigidArr)
        {
            rigid.AddForce(dir * power, ForceMode2D.Impulse);
        }
    }

    //��ġ ����
    public void Reset()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.rotation = Quaternion.identity; // 0���� ȸ���� �÷��ְ�
            child.localPosition = _initPosition[i];
        }
    }
}
