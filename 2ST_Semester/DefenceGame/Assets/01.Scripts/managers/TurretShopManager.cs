using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _turretCardPrefab;
    [SerializeField] private Transform _turretPanelContainer;

    [Header("TurretSettingsSO")]
    [SerializeField] private TurretSettingsSO[] _turrets; //ScriptableObject 배열

    private void Start() 
    {
        for (int i = 0; i < _turrets.Length; i++)
            CreateTurretCard(_turrets[i]);
    }

    private void CreateTurretCard(TurretSettingsSO turretSettingsSO)
    {
        GameObject newInstance = Instantiate(_turretCardPrefab, _turretPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(_turretPanelContainer);
        newInstance.transform.localScale = Vector3.one;
        
        TurretCard cardButton = newInstance.GetComponent<TurretCard>();
        cardButton.SetupTurretButton(turretSettingsSO);
    }
}
