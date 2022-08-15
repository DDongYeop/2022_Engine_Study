using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon; //�ڱⰡ ����ִ� weapon
    protected WeaponRenderer _weaponRenderer;
    protected float _desireAngel; //���Ⱑ �ٶ󺸰����ϴ� ����

    [SerializeField] private int _maxTotalAmmo = 2000, _totalAmmo = 200; //200 / 2000�� ������
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

        AdjustWeaponRendering(); //���⸦ ������

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
            _weapon.PlayCannotSound(); //źȯ ���� ���� ���
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
            _weapon.StopShooting(); //�������� �� ��°� ���߰�
            StartCoroutine(ReladCorutine());
        }
        else
        {
            _weapon.PlayCannotSound(); //źȯ ���� ���� ���
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
