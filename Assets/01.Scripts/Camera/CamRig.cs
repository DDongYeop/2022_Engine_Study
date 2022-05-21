using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamRig : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private PolygonCollider2D _confiner;
    [SerializeField] private CinemachineVirtualCamera _cmRigCam;

    private Vector3 _boundMax;
    private Vector3 _boundMin;
    private float _halfWidth;


    void Start()
    {
        _boundMax = _confiner.bounds.max;
        _boundMin = _confiner.bounds.min;

        float otho = _cmRigCam.m_Lens.OrthographicSize;
        _halfWidth = otho * 16 / 9;
    }

    void Update()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 pos = transform.position;
        float min = _boundMin.x + _halfWidth;
        float max = _boundMax.x + _halfWidth;
        pos.x = Mathf.Clamp(pos.x + _moveSpeed * x * Time.deltaTime, min, max);

        transform.position = pos;
    }
}
