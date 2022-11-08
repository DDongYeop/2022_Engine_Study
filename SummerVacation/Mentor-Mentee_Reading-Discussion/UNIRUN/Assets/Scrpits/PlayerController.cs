using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip dieClip;
    public float jumpForce = 700f;

    private int _jumpCount = 0;
    private bool isGround = false;
    private bool _isDead = false;

    private AudioSource _audioSource;
    private Rigidbody2D _rigid;
    Animator _animator;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isDead == true)
            return;

        if (Input.GetMouseButtonDown(0) && _jumpCount < 2)
        {
            _jumpCount++;
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(new Vector2(0, jumpForce));
            _animator.SetTrigger("IsJump");
            _audioSource.Play();
        }
        else if (Input.GetMouseButtonUp(0) && _rigid.velocity.y > 0)
        {
            _rigid.velocity = _rigid.velocity * 0.5f;
        }

    }

    private void Die()
    {
        _animator.SetTrigger("IsDie");
        _audioSource.clip = dieClip;
        _audioSource.Play();

        _rigid.velocity = Vector2.zero;
        _isDead = true;
        GameManager.instance.OnPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
            _jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead" && _isDead == false)
        {
            Die();  
        }
    }
}
