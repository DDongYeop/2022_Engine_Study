using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon; //자기가 들고있는 weapon
    protected WeaponRenderer _weaponRenderer;
    protected float _desireAngel; //무기가 바라보고자하는 방향

    [SerializeField] private int _maxTotalAmmo = 2000, _totalAmmo = 200; //200 / 2000발 보유중
    protected bool _isReloading = false;
    public bool IsReloading { get => _isReloading; }

    protected virtual void Awake()
    {
        AssignWeapon();
    }

    public virtual void AssignWeapon()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDirection = (Vector3)pointerPos - transform.position;
        _desireAngel = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        AdjustWeaponRendering(); //무기를 렌더링

        transform.rotation = Quaternion.AngleAxis(_desireAngel, Vector3.forward);
    }

    private void AdjustWeaponRendering()
    {
        _weaponRenderer.FlipSprite(_desireAngel > 90f || _desireAngel < -90f);
        _weaponRenderer.RenderBehindHead(_desireAngel > 0 && _desireAngel < 180f);
    }

    public virtual void Shoot()
    {
        if (_isReloading == true)
        {
            _weapon.PlayCannotSound(); //탄환 없음 사운드 출력
            return;
        }
        _weapon.TryShooting();
    }

    public virtual void StopShooting()
    {
        _weapon.StopShooting();
    }

    public void ReloadGun()
    {
        if (_isReloading == false && _totalAmmo > 0 && _weapon.AmmoFull == false)
        {
            _isReloading = true;
            _weapon.StopShooting(); //재장전시 총 쏘는거 멈추고
            StartCoroutine(ReladCorutine());
        }
        else
        {
            _weapon.PlayCannotSound(); //탄환 없음 사운드 출력
        }
    }

    IEnumerator ReladCorutine()
    {
        yield return new WaitForSeconds(_weapon.WeaponData.reloadTime);

        _weapon.PlayReloadSound();

        int reloadedAmmo = Mathf.Min(_totalAmmo, _weapon.EmptyBulletCnt);
        _totalAmmo -= reloadedAmmo;
        _weapon.Ammo += reloadedAmmo;

        _isReloading = false;
    }
}
