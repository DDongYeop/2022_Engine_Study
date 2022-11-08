using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DFreedom : MonoBehaviour
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

        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        _animator.SetFloat("Horizontal", horizontal * offset);
        _animator.SetFloat("Vertical", vertical * offset);
    }
}
