using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    //마지막으로 보고 있던 방향을 보게 
    public override void TakeAction()
    {
        _brain.Move(Vector2.zero, _brain.target.position);
    }
}
