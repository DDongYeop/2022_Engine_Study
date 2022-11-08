using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;
    public static Action OnTurretSold;

    [SerializeField] private GameObject _attackRangeSprite;

    public Turret Turret { get; set; }

    private float _rangeSize;
    private Vector3 _rangeOriginalSize; 

    private void Start()
    {
        _rangeSize = _attackRangeSprite.GetComponent<SpriteRenderer>().bounds.size.y;
        _rangeOriginalSize = _attackRangeSprite.transform.localScale;
    }

    private void ShowTurretInfo()
    {
        _attackRangeSprite.SetActive(true);
        _attackRangeSprite.transform.localScale = _rangeOriginalSize * this.Turret.AttackRange / (_rangeSize / 2);
    }

    public void SetTurret(Turret turret)
    {
        this.Turret = turret;
    }

    public bool IsEmpty()
    {
        return this.Turret == null;
    }

    public void SelectTurret()
    {
        OnNodeSelected?.Invoke(this);
        if (!IsEmpty())
            ShowTurretInfo();
    }

    public void SellTurret()
    {
        if (!IsEmpty())
        {
            MoneySystem.Instance.AddCoins(Turret.TurretUpgrade.GetSellValue());
            Destroy(this.Turret.gameObject);
            this.Turret = null;

            _attackRangeSprite.SetActive(false  );

            OnTurretSold?.Invoke();
        }
    }
}
