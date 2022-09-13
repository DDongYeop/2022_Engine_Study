using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private WayPoint _wayPoint;

    public Vector3 CurrentPointPosition => _wayPoint.GetWayPointPosition(_currentWaypointIndex);

    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        if (_wayPoint.points.Length == _currentWaypointIndex)
            return;

        Move();
        
        if (CurrentPointPositionReached())
            _currentWaypointIndex++;
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
}
