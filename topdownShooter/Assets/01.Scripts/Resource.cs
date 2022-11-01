using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : PoolAbleMono
{
    [SerializeField] public ResourceDataSO ResourceData;
    private AudioSource _audioSource;
    private CircleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = ResourceData.useSound;
        _collider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PickUpResource() //리소스 집었을떄 동작할 매서드
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length + 0.3f);

        PoolManager.Instance.Push(this);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        transform.DOKill();
    }

    public override void Init()
    {
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }
}
