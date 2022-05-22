using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionParticle;
    [SerializeField] private LayerMask _whatIsDamageable;

    [SerializeField] private float _expRadius = 2f;
    [SerializeField] private float _expPower = 100f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction, float power)
    {
        _rigidbody2D.AddForce(direction * power);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isDestory = CheckDestory();
        ParticleSystem ps = Instantiate(_explosionParticle, transform.position, Quaternion.identity) as ParticleSystem;
        ps.Play();
        GameManager.Instance.PlayExplosionSound(); //파괴 사운드 재생
        GameManager.Instance.BackToRigCam(2f);
        Destroy(ps.gameObject, 2f);
        Destroy(gameObject);
    }

    //내가 터지는 주변에 박스들이 존재하는지를 검사해서 폭팔
    private bool CheckDestory()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, _expRadius, _whatIsDamageable);

        bool isCol = false;

        foreach(Collider2D col in cols)
        {
            IDamageable iDmg = col.GetComponent<IDamageable>();
            if (iDmg != null)
            {
                Vector2 dir = col.transform.position - transform.position;
                float power = ((_expRadius + 1) - dir.magnitude) * _expPower;
                iDmg.OnDamage(1, gameObject, dir.normalized, power);
                isCol = true;
            }
        }

        return isCol;
    }
}
