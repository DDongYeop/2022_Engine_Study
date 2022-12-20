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
        float horizontal = Input.GetAxis("Horizontal"); //좌우
        float vertical = Input.GetAxis("Vertical"); //위아래 키 눌러서

        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
    }
}
