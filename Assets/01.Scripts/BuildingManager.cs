using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;

    public class OnActiveBuildingTypeChangedEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuildingType;
    }

    private Camera _mainCamera;
    private BuildingTypeListSO _buildingTypeList;
    private BuildingTypeSO _activeBuildingType;

    private void Awake()
    {
        Instance = this;

        _buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            if (_activeBuildingType != null && CanSpawnBuilding(_activeBuildingType, UtilsClass.GetMouseWorldPosition()))
                Instantiate(_activeBuildingType.prefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        _activeBuildingType = buildingType;

        OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = _activeBuildingType});
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return _activeBuildingType;
    }

    private bool CanSpawnBuilding(BuildingTypeSO buildingType, Vector3 position)
    {
        BoxCollider2D boxCollider2D = buildingType.prefab.GetComponent<BoxCollider2D>();
        
        Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0);

        bool isAreaClear = collider2DArray.Length == 0;
        if (!isAreaClear)
            return false;

        collider2DArray = Physics2D.OverlapCircleAll(position, buildingType.minConstructionRadius);

        foreach(Collider2D collider in collider2DArray)
        {
            BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
            if (buildingTypeHolder != null)
            {
                if (buildingTypeHolder.buildingType == buildingType)
                    return false;
            }
        }

        float maxContrustRadius = 25f;
        collider2DArray = Physics2D.OverlapCircleAll(position, maxContrustRadius);

        foreach (Collider2D collider in collider2DArray)
        {
            BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
            if (buildingTypeHolder != null)
                return true;
        }

        return false;
    }
}
