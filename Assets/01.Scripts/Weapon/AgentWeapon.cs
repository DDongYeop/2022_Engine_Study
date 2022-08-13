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

        //여기에 렌더링 해주는거 들어가야 함

        transform.rotation = Quaternion.AngleAxis(_desireAngel, Vector3.forward);
    }
}
