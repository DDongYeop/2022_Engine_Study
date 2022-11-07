using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretCard : MonoBehaviour
{
    public static Action<TurretSettingsSO> OnPlaceTurret;

    [SerializeField] private Image _turretImage;
    [SerializeField] private TextMeshProUGUI _turretCost;

    public TurretSettingsSO TurretLoaded { get; set; }

    public void SetupTurretButton(TurretSettingsSO turretSettingsSO)
    {
        TurretLoaded = turretSettingsSO;
        _turretImage.sprite = turretSettingsSO.TurretShopSprite;
        _turretCost.text = turretSettingsSO.TurretShopCost.ToString();
    }

    public void PlaceTurret()
    {
        if (MoneySystem.Instance.TotalCoins >= TurretLoaded.TurretShopCost)
        {
            MoneySystem.Instance.RemoveCoins(TurretLoaded.TurretShopCost);
            UIManager.Instance.CloseTurretShopPanel();
            OnPlaceTurret?.Invoke(TurretLoaded);
        }
    }
}
