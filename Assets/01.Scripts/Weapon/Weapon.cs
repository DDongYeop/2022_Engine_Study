using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    #region 발사 관련 로직
    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting;
    protected bool _isShooting = false;
    protected bool _delayCorourine = false;
    #endregion

    [SerializeField] protected WeaponDataSO _weaponData;
    [SerializeField] protected GameObject _muzzle; //총구위치
    [SerializeField] protected TrackedReference _shellEjectPos; //탄피 생성 지점
    
    public WeaponDataSO WeaponData { get => _weaponData; }

    #region AMMO관련 코드
    public UnityEvent<int> OnAmmoChange; //총알변경시 발생할 이벤트
    [SerializeField] protected int _ammo;
    public int Ammo
    {
        get => _ammo;
        set
        {
            _ammo = Mathf.Clamp(value, 0, _weaponData.ammoCapacity);
            OnAmmoChange?.Invoke(_ammo);
        }
    }
    public bool AmmoFull { get => Ammo == _weaponData.ammoCapacity; }
    public int EmptyBulletCNt { get => _weaponData.ammoCapacity - _ammo; }
    #endregion

    private void Start()
    {
        //나중에 변경
        Ammo = _weaponData.ammoCapacity;
        WeaponAudio wa= transform.Find("WeaponAudio").GetComponent<WeaponAudio>();
        wa.SetAudioClip(_weaponData.shootClip, _weaponData.outOfAudioClip, _weaponData.reloadClip);
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        //마우스 클릭중, 총의 딜레이가 false면 발사
        if (_isShooting && _delayCorourine == false)
        {
            if (Ammo > 0)
            {
                Ammo -= _weaponData.GetBulletCountToSpawn();

                OnShoot?.Invoke();
                for (int i = 0; i < _weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                _isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishShooting();
        }
    }

    protected void FinishShooting()
    {
        StartCoroutine(DelayNextShootCorutine());
        if (_weaponData.automaticFire == false)
        {
            _isShooting = false;
        }
    }

    protected IEnumerator DelayNextShootCorutine()
    {
        _delayCorourine = true;
        yield return new WaitForSeconds(_weaponData.weaponDelay);
        _delayCorourine = false;
    }

    private void ShootBullet()
    {
        Debug.Log("총알 발사 !");
    }

    public void TryShooting()
    {
        _isShooting = true;
    }
    public void StopShooting()
    {
        _isShooting = false;
        OnStopShooting?.Invoke();
    }
}
