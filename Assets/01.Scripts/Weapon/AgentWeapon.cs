using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected WeaponRenderer _weaponRenderer;
    protected float _desireAngel; //무기가 바라보고자하는 방향

    protected virtual void Awake()
    {
        AssignWeapon();
    }

    public virtual void AssignWeapon()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
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
}
