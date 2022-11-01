using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDistance : AIDecision
{
    [Range(.1f, 30f)] public float distance = 5f;

    public override bool MakeDecision()
    {
        float calc = Vector2.Distance(_brain.target.position, transform.position);

        if (calc < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() 
    {
        if (UnityEditor.Selection.activeObject == gameObject)
        {
            Color oldcolor = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, distance);
            Gizmos.color = oldcolor;
        }
    }
#endif
}
