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
        float vertical = Input.GetAxis("Vertical"); //위아래키 눌러서
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f; //shift키를 안 누르면 최대 .5f, 누르면 최대 1까지 바뀌도록
        float moveParameter = Mathf.Abs(vertical * offset);

        _animator.SetFloat("moveSpeed", moveParameter); //0 : 대기, .5f면 걷기, 1이면 뛰기
    }
}
