using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected WeaponRenderer _weaponRenderer;
    protected float _desireAngel; //���Ⱑ �ٶ󺸰����ϴ� ����

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

        //���⿡ ������ ���ִ°� ���� ��

        transform.rotation = Quaternion.AngleAxis(_desireAngel, Vector3.forward);
    }
}
