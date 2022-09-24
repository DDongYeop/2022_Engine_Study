using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private ResourceGeneratorData _resourceGeneratorData;
    private float _timer;
    private float _timerMax;

    private void Awake()
    {
        _resourceGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.resourceGeneratorData;
        _timerMax = _resourceGeneratorData.timerMax;
    }

    private void Start()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, _resourceGeneratorData.resourceDetectionRadius);

        int nearbyResourceAmount = 0;
        foreach (Collider2D collider2D in collider2DArray)
        {
            ResourceNode resouceNode = collider2D.GetComponent<ResourceNode>();
            if (resouceNode != null)
            {
                if (resouceNode.resourceType == _resourceGeneratorData.resourceType)
                    nearbyResourceAmount++;
            }
        }

        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, _resourceGeneratorData.maxResourceAmount);

        if (nearbyResourceAmount == 0)
        {
            enabled = false;
        }
        else
            _timerMax = (_resourceGeneratorData.timerMax / 2f) + _resourceGeneratorData.timerMax * (1 - (float)nearbyResourceAmount / _resourceGeneratorData.maxResourceAmount);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer += _timerMax;
            ResourceManager.Instance.AddResource(_resourceGeneratorData.resourceType, 1);
        }    
    }
}
