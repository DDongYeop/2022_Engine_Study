using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected float _timeToLive;

    protected int _enemyLayer;
    protected int _obstacleLayer;

    protected bool _isDead = false; //총알 한개가 여러명한테 동시에 맞았을때 한명에게만 적용되도혹 하는거

    [SerializeField] protected BulletDataSO _bulletData;
    protected bool _isEnemy;
    public bool IsEnemy
    {
        get => _isEnemy;
        set => _isEnemy = value;
    }

    private void Awake()
    {
        _obstacleLayer = LayerMask.NameToLayer("Obstacle"); //장애물 레이어의 번호를 알아오고
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetPosionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }

    private void FixedUpdate()
    {
        _timeToLive += Time.fixedDeltaTime;
        _rigidbody.MovePosition(transform.position + _bulletData.bulletSpeed * transform.right * Time.fixedDeltaTime);

        if (_timeToLive >= _bulletData.lifeTime)
        {
            _isDead = true;
            Destroy(gameObject); //나중엔 풀링으로 변경
        }
    }
}
