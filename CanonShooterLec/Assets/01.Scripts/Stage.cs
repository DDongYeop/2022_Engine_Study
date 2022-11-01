using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private int _totalCrateCount;
    private List<Crate> _crateList = new List<Crate>();
    private Transform _positionTrm;

    private PolygonCollider2D _camBound;
    public PolygonCollider2D CamBound
    {
        get => _camBound;
    }

    public int BoxCount
    {
        get => _totalCrateCount;
    }

    public Vector3 CannonPosition
    {
        get => _positionTrm.position;
    }

    private void Awake()
    {
        _crateList = new List<Crate>();
        transform.Find("CrateList").GetComponentsInChildren<Crate>(_crateList);
        _totalCrateCount = _crateList.Count;

        _camBound = transform.Find("VCamComfiner").GetComponent<PolygonCollider2D>();

        _positionTrm = transform.Find("CannonPosition");
    }

    public void Init(Action CExpAction)
    {
        _crateList.ForEach(c => c.OnExplosion += CExpAction);
    }
}
