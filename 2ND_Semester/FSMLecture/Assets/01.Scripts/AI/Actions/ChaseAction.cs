using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    private Vector3Int _beforeTargetPos = Vector3Int.zero;
    //목표지점이 바뀔떄마다 경로를 계산할꺼니깐 타일 범위를 벗어나는 움직임이 아니라면 
    private Vector3 _nextPos; //다음으로 갈 경로 

    public override void TakeAction()
    {
        //목표를 향해 이동하도록 
        // Vector2 direction = _brain.target.position - transform.position;
        // _brain.Move(direction.normalized, _brain.target.position);

        //내 목표가 변경 되었는가?
        Vector3Int targetPos = MapManager.Instance.GetTilePos(_brain.target.position);
        if (targetPos != _beforeTargetPos)
        {
            //새롭게 경로 계산하여야 하고
            _brain.Agent.Destination = targetPos; //자동으로 경로 계산된다. 
            _beforeTargetPos = targetPos;
            SetNextPos();
        }

        if (Vector3.Distance(_nextPos, transform.position) <= 0.2f)
        {
            SetNextPos(); //다음으로 가야할 스폿 포인트 받아오고
        }

        //다음으로 가야할 스폿 포인트를 받아서 _nextPos에 넣은거니까 해당 방향으로 진행 시키면 된다
        _brain.Move( (_nextPos - transform.position).normalized, _brain.target.position);

    }

    private void SetNextPos()
    {
        Vector3Int nextTarget = _brain.Agent.GetNextTarget();
        if (nextTarget == Vector3Int.zero)
        {
            _brain.Move(Vector3.zero, _brain.target.position);
            _nextPos = transform.position;
        }
        else
            _nextPos = MapManager.Instance.GetWorldPos(_brain.Agent.GetNextTarget());
    }
}
