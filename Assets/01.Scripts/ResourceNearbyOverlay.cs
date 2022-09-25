using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceNearbyOverlay : MonoBehaviour
{
    private ResourceGeneratorData _resourceGeneratorData;

    private void Awake()
    {
        Hide();
    }

    private void Update()
    {
        int nearbyResourceAmount = ResourceGenerator.GetNearbtResourceAmount(_resourceGeneratorData, transform.position);
        float percent = Mathf.RoundToInt((float)nearbyResourceAmount / _resourceGeneratorData.maxResourceAmount * 100f);
        transform.Find("Text").GetComponent<TextMeshPro>().SetText(percent + "%");
    }

    public void SHow(ResourceGeneratorData resourceGeneratorData)
    {
        this._resourceGeneratorData = resourceGeneratorData;
        gameObject.SetActive(true);

        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite = _resourceGeneratorData.resourceType.sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
