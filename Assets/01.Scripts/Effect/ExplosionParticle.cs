using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : PoolableMono
{
    [SerializeField] private float _lifeTime = 1.5f;

    public override void Reset()
    {
        //���⼭ ���ٰ� ���� ����
    }

    public void SetPositionAndPlay(Vector3 pos)
    {
        transform.position = pos;
        StartCoroutine(DelayCo());
    }

    IEnumerator DelayCo()
    {
        yield return new WaitForSeconds(_lifeTime);
        //���⼭ �ٽ� ���� �ִ� ���� �ۻ��ؾ���
    }
}
