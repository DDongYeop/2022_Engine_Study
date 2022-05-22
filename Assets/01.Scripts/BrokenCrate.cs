using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCrate : MonoBehaviour
{
    private Vector3[] _initPosition;
    private Rigidbody2D[] _childRigidArr;

    private void Awake()
    {
        _initPosition = new Vector3[transform.childCount]; //자식의 갯수만큼 배열 생성
        _childRigidArr = new Rigidbody2D[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            _initPosition[i] = child.localPosition;//꼭 로컬로 저장 해야함
            //안 그러면 월드 좌표로 생성되어 리셋할 때마다 처음 위치로 돌아가버림
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

    //위치 복구
    public void Reset()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.rotation = Quaternion.identity; // 0으로 회전도 올려주고
            child.localPosition = _initPosition[i];
        }
    }
}
