using UnityEngine;

[CreateAssetMenu(menuName = "SO/WEAPON/BulletData")]
public class BulletDataSO : ScriptableObject
{
    public GameObject bulletPrefab;
    [Range(1, 10)] public int damage = 1;
    [Range(1, 100)] public float bulletSpeed = 1;

    public GameObject impactObstaclePrefab; //장애물에 부딛혔을때의 효과
    public GameObject impactEnemtPrefab; //플레이어에 부딛혔을 떄의 효과 

    public float lifeTime = 2f;
}
