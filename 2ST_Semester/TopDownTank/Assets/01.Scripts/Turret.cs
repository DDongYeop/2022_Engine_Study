using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Turret : MonoBehaviour
{
    [SerializeField] private List<Transform> _turretBarrels;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _reloadDelay = 1;

    private bool _canShoot = true;
    private Collider2D[] _tankColliders;
    private float _currentDelay = 0;

    private ObjectPool _bulletPool;
    [SerializeField] private int _bulletPoolCount = 10;

    private void Awake() 
    {
        _tankColliders = GetComponentsInParent<Collider2D>();
        _bulletPool = GetComponent<ObjectPool>();
    }

    private void Start() 
    {
        _bulletPool.Initialized(_bulletPrefab, _bulletPoolCount);
    }

    private void Update() 
    {
        if (!_canShoot)
        {
            _currentDelay -= Time.deltaTime;
            if (_currentDelay <= 0)
                _canShoot = true;
        }
    }

    public void Shoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            _currentDelay = _reloadDelay;

            foreach (var barrel in _turretBarrels)
            {
                //GameObject bullet = Instantiate (_bulletPrefab);
                GameObject bullet = _bulletPool.CreateObject();
                bullet.transform.position = barrel.transform.position;
                bullet.transform.rotation = barrel.transform.rotation;
                bullet.GetComponent<Bullet>().Initializes();

                foreach(var collider in _tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }
}
