using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1D : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical"); //���Ʒ�Ű ������
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f; //shiftŰ�� �� ������ �ִ� .5f, ������ �ִ� 1���� �ٲ��
        float moveParameter = Mathf.Abs(vertical * offset);

        _animator.SetFloat("moveSpeed", moveParameter); //0 : ���, .5f�� �ȱ�, 1�̸� �ٱ�
    }
}
