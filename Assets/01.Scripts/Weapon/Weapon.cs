using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    #region �߻� ���� ����
    public UnityEvent OnShot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting;
    protected bool _isShooting = false;
    protected bool _delayCorourine = false;
    #endregion

    #region AMMO���� �ڵ�
    public UnityEvent<int> OnAmmoChange; //�Ѿ˺���� �߻��� �̺�Ʈ
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
        //���콺 Ŭ����, ���� �����̰� false�� �߻�
        if (_isShooting && _delayCorourine == false)
        {

        }
    }
}
