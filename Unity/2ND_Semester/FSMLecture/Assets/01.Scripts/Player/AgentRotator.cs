using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRotator : MonoBehaviour
{
    private float _targetDegree;
    private float _rotateSpeed;

    public void SetRotateSpeed(float value)
    {
        _rotateSpeed = value;
    }

    public void SetTarget(Vector3 pos)
    {
        Vector3 delta = pos - transform.position;
        _targetDegree = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
    }

    private void Update() 
    {
        //rotate스피드는 1초에 회전하는 각도를 말한다 
        //내가 바라보고자 하는 방향으로 rotate스피드 만큼 회전하게 
        Quaternion targetRot = Quaternion.AngleAxis(_targetDegree, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * _rotateSpeed);
    }
}
