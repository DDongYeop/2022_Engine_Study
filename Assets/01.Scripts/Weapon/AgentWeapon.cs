using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon; //�ڱⰡ ����ִ� weapon
    protected WeaponRenderer _weaponRenderer;
    protected float _desireAngel; //���Ⱑ �ٶ󺸰����ϴ� ����

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
        _weapon.TryShooting();
    }

    public virtual void StopShooting()
    {
        _weapon.StopShooting();
    }
}
