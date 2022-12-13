using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : AIDecision
{
    public override bool MakeADecision()
    {
        float radius = _brain.viewRange;
        int playerLayer = LayerMask.NameToLayer("Player");
        // int playerLayer = LayerMask.GetMask("Player"); // << 하는 비트연산 불 필요
        Collider2D col = Physics2D.OverlapCircle(transform.position, radius, 1 << playerLayer);

        if (col != null)
        {
            Vector3 dir = (col.transform.position - transform.position).normalized;

            if(Vector3.Angle(transform.right, dir) < _brain.viewAngle * 0.5f)
                return true;
        }
        return false;
    }
}
