using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action OnEndReached;

    [SerializeField] private float _moveSpeed = 3.0f;

    public WayPoint waypoint { get; set; }

    public Vector3 CurrentPointPosition => waypoint.GetWayPointPosition(_currentWaypointIndex);

    private int _currentWaypointIndex;

    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        /*if (_currentWaypointIndex == _wayPoint.points.Length)
            return;*/

        Move();
        
        if (CurrentPointPositionReached())
            UpdateCurrentPointIndex();
    }

    private void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, _moveSpeed * Time.deltaTime);

        if (CurrentPointPosition == transform.position && transform.position != transform.position)
            _currentWaypointIndex++;
    }

    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPotion = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPotion < 0.1f)
            return true;
        else
            return false;
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = waypoint.points.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
            _currentWaypointIndex++;
        else
            EndPointReached();
    }

    private void EndPointReached()
    {
        OnEndReached?.Invoke(); // if (OndEndReached != null) OnEndReached.Invoke(); << 이거랑 똑같음
        
        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetEnemy()
    {
        _currentWaypointIndex = 0;
    }
}
