using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPartolPathBehaviour : AIBehaviour
{
    public PatrolPath patrolPath;
    [Range(0.1f, 1f)]
    public float arriveDistance = 1;
    public float waitTime = 0.5f;

    [SerializeField] 
    private bool isWaiting = false;
    [SerializeField]
    Vector2 currentPatrolTarget = Vector2.zero;
    bool isInitialized = false;

    private int currentIndex = -1;

    private void Awake() 
    {
        if (patrolPath == null) patrolPath = GetComponentInChildren<PatrolPath>();
    }

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (tank == null || detector == null)
            return;

        if (!isWaiting)
        {
            if (patrolPath.Legth < 2) return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(tank.transform.position);
                currentIndex = currentPathPoint.Index;
                currentPatrolTarget = currentPathPoint.Position;
                isInitialized = true;
            }

            if (Vector2.Distance(tank.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }

            Vector2 directionToGo = currentPatrolTarget - (Vector2)tank.transform.position;
            var dotProdect = Vector2.Dot(tank.tankMover.transform.up, directionToGo.normalized);

            if (dotProdect < 0.98f)
            {
                var crossProdect = Vector3.Cross(tank.tankMover.transform.up, directionToGo.normalized);
                int rotationResult = crossProdect.z >= 0 ? -1 : 1;
                tank.HandleMoveBody(new Vector2(rotationResult,1 ));
            }
            else
            {
                tank.HandleMoveBody(Vector2.up);
            }
        }
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nextPathPoint.Position;
        currentIndex = nextPathPoint.Index;
        isWaiting = false;
    }
}
