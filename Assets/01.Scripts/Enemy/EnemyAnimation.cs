using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : AgentAnimation
{
    protected EnemyAIBrain _brain;
    protected readonly int _attackHash = Animator.StringToHash("Attack");
    protected readonly int _DeadBoolHash = Animator.StringToHash("IsDead");

    protected override void Awake()
    {
        base.Awake();
        _brain = transform.parent.GetComponent<EnemyAIBrain>();
    }

    public void SetEndOfAttackAnimation()
    {
        //���⼭ �극���� ���ؼ� ���� ���� ���� �ؾ���
        _brain.AIActionData.isAttack = false;
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(_attackHash);
    }

    public void PlayDeadAnimation()
    {
        _animator.SetBool(_DeadBoolHash, true);
        _animator.SetTrigger(_deadHash);
    }

    public void EndOfDeadAnimation()
    {
        _brain.Enemy.Die(); //�ִϸ��̼� ��� �������� ������ �׿���
    }
}
