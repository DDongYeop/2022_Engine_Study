using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WayPoint))]  // waypoint ´ëÇØ¼­ custom
public class WayPointEditor : Editor
{
    private WayPoint _wayPoints => target as WayPoint;

    private void OnSceneGUI()
    {
        for (int i = 0; i < _wayPoints.points.Length; i++)
        {
            //create handle
            Vector3 currentWatpointPoint = _wayPoints.currentPosition + _wayPoints.points[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWatpointPoint, Quaternion.identity, 0.7f, new Vector3(x:0.3f, y:0.3f, z:0.3f), Handles.SphereHandleCap);
        }
    }
}
