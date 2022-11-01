using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Turret Shop Setting", menuName = "SO/TurretSettings")]
public class TurretSettingsSO : ScriptableObject
{
    public GameObject TurretPrefab;
    public int TurretShopCost;
    public Sprite TurretShopSprite;
}
