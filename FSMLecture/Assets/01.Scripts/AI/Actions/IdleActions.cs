using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleActions : AIAction
{
    public override void TakeAction()
    {
        // 이때는 멈춰를 시전해야댐
        Debug.Log("현재 Idle액션 실행중");
    }
}
