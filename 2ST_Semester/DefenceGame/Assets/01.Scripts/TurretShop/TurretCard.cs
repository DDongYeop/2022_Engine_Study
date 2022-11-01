using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretCard : MonoBehaviour
{
    [SerializeField] private Image _turretImage;
    [SerializeField] private TextMeshProUGUI _turretCost;

    public void SetupTurretButton(TurretSettingsSO turretSettingsSO)
    {
        _turretImage.sprite = turretSettingsSO.TurretShopSprite;
        _turretCost.text = turretSettingsSO.TurretShopCost.ToString();
    }
}
