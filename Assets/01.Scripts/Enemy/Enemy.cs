using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent
{
    public bool IsEnemy => true;

    public Vector3 HitPoint { get; private set; }

    public int Heath { get; private set; }

    [field: SerializeField] public UnityEvent OnDie { get; set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }

    protected bool _isActive = false; //등장 후 액티브 시켜주면 그제야 동작할거다.
    protected EnemyAIBrain _brain;
    protected EnemyAttack _attack;

    [SerializeField] protected EnemyDataSO _enemyData;
    public EnemyDataSO EnemyData { get => _enemyData; }

    protected virtual void Awake()
    {
        _brain = GetComponent<EnemyAIBrain>();
        _attack = GetComponent<EnemyAttack>();
        _attack.AttackDelay = _enemyData.attackDelay; //공격딜레이를 셋팅

        transform.Find("AI/IdleState/TranChase").GetComponent<DecisionInner>().Distance = _enemyData.chaseRange;
        transform.Find("AI/ChaseState/TranIdle").GetComponent<DecisionInner>().Distance = _enemyData.chaseRange;

        transform.Find("AI/ChaseState/TranAttack").GetComponent<DecisionInner>().Distance = _enemyData.attackRange;
        transform.Find("AI/AttackState/TranChase").GetComponent<DecisionOuter>().Distance = _enemyData.attackRange;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        throw new System.NotImplementedException();
    }
}
