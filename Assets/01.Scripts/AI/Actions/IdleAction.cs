using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        //여기엔 데이터 저장하는 부분이 필요
        _brain.Move(Vector2.zero, transform.position);
    }
}
