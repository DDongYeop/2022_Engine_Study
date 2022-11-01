using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseActions : AIAction
{
    public override void TakeAction()
    {
        //목표를 향해 이동하도록
        Vector2 direction = _brain.target.position - transform.position;

        _brain.Move(direction.normalized, _brain.target.position);
    }
}
