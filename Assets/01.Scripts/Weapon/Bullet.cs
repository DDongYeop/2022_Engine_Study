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
    public BulletDataSO BulletData
    {
        get => _bulletData;
        set => _bulletData = value;
    }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead == true) return;
        
        if (collision.gameObject.layer == _obstacleLayer)
            HitObstacle(collision);
        if (collision.gameObject.layer == _enemyLayer)
            HitEnemy(collision);
        
        _isDead = true;
        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D col)
    {
        //do nothing
    }

    private void HitObstacle(Collider2D col)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10f);
        //실질적인 데미지 처리는 여기에서 이뤄져야한다. (아직 안함)

        if (hit.collider != null)
        {
            Impact impact = Instantiate(_bulletData.impactObstaclePrefab).GetComponent<Impact>();
            Quaternion rot = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
            impact.SetPostionAndRotation(hit.point + (Vector2)transform.right * 0.5f, rot);
            impact.SetScaleAndTime(Vector3.one, 0.2f);
        }
    }
}
