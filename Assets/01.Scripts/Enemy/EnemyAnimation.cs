using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private Enemy _enemy;
    private EnemyHealth _enemyHealth;

    private int _hurtAnimation = Animator.StringToHash("Hurt");
    private int _dieAnimation = Animator.StringToHash("Die");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void PlayHurtAnimation()
    {
        _animator.SetTrigger(_hurtAnimation);
    }

    private void PlayDieAnimation()
    {
        _animator.SetTrigger(_dieAnimation);
    }

    private float GetCurrentANimationLength()
    {
        float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
        return animationLength;
    }

    private IEnumerator PlayerHurt()
    {
        _enemy.StopMovement();
        PlayHurtAnimation();
        yield return new WaitForSeconds(GetCurrentANimationLength() + .25f);
        _enemy.ResumeMovement();
    }

    private void EnemyHit(Enemy enemy)
    {
        if (_enemy == enemy)
            StartCoroutine(PlayerHurt());
    }

    private IEnumerator PlayerDie()
    {
        _enemy.StopMovement();
        PlayDieAnimation();
        yield return new WaitForSeconds(GetCurrentANimationLength());
        _enemy.ResumeMovement();

        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(_enemy.gameObject);
    }

    public void EnemyDead(Enemy enemy)
    {
        if (_enemy == enemy)
            StartCoroutine(PlayerDie());
    }

    private void OnEnable()
    {
        EnemyHealth.onEnemyHit += EnemyHit;
        EnemyHealth.onEnemyKilled += EnemyDead;
    }

    private void OnDisable()
    {
        EnemyHealth.onEnemyHit -= EnemyHit;
        EnemyHealth.onEnemyKilled -= EnemyDead;
    }
}
