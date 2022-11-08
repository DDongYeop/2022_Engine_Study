using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    private Node _curretNodeSelected;

    [Header("Panels")]
    [SerializeField] private GameObject _turretShopPanel;
    [SerializeField] private GameObject _nodeUIPanel;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private TextMeshProUGUI _sellText;
    [SerializeField] private TextMeshProUGUI _turretLevelText;

    public void CloseTurretShopPanel()
    {
        _turretShopPanel.SetActive(false);
    }

    private void OnEnable() 
    {
        Node.OnNodeSelected += NodeSelected;
    }

    private void OnDisable() 
    {
        Node.OnNodeSelected -= NodeSelected;        
    }

    private void NodeSelected(Node nodeSelected)
    {
        _curretNodeSelected = nodeSelected;
        if (_curretNodeSelected.IsEmpty())
            _turretShopPanel.SetActive(true);
        else
            SHowNodeUI();
    }

    private void SHowNodeUI()
    {
        _nodeUIPanel.SetActive(true);
        _upgradeText.text = _curretNodeSelected.Turret.TurretUpgrade.UpgradeCost.ToString();
        
        UpdateUpgradeText();
        UpdateTurretLevel();
        UpdateSellValue();

    }

    public void UpgradeTurret()
    {
        _curretNodeSelected.Turret.TurretUpgrade.UpgradeTurret();
        UpdateUpgradeText();
        UpdateTurretLevel();
        UpdateSellValue();
    }

    private void UpdateUpgradeText()
    {
        _upgradeText.text = _curretNodeSelected.Turret.TurretUpgrade.UpgradeCost.ToString();
    }

    private void UpdateTurretLevel()
    {
        _turretLevelText.text = $"Level {_curretNodeSelected.Turret.TurretUpgrade.Level}";
    }

    private void UpdateSellValue()
    {
        int sellAmount = _curretNodeSelected.Turret.TurretUpgrade.GetSellValue();
        _sellText.text = sellAmount.ToString();
    }

    public void SellTurret()
    {
        _curretNodeSelected.SellTurret();
        _curretNodeSelected = null;
        _nodeUIPanel.SetActive(false);
    }
}
