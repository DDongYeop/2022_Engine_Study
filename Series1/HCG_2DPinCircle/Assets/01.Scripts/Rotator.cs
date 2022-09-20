using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private Vector3 _rotateAngle = Vector3.forward;

    private void Update()
    {
        transform.Rotate(_rotateAngle * _rotateSpeed * Time.deltaTime);
    }
}
