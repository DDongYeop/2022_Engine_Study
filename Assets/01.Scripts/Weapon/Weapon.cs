using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    #region 발사 관련 로직
    public UnityEvent OnShot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting;
    protected bool _isShooting = false;
    protected bool _delayCorourine = false;
    #endregion

    #region AMMO관련 코드
    public UnityEvent<int> OnAmmoChange; //총알변경시 발생할 이벤트
    [SerializeField] protected int _ammo;
    public int Ammo
    {
        get => _ammo;
        set
        {
            _ammo = Mathf.Clamp(value, 0, 200);
            OnAmmoChange?.Invoke(_ammo);
        }
    }
    #endregion

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        //마우스 클릭중, 총의 딜레이가 false면 발사
        if (_isShooting && _delayCorourine == false)
        {

        }
    }
}
