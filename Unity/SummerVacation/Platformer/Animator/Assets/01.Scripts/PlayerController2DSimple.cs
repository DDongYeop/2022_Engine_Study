using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DSimple : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //�¿�
        float vertical = Input.GetAxis("Vertical"); //���Ʒ� Ű ������

        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
    }
}
