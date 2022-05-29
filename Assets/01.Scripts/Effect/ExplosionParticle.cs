using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : PoolableMono
{
    [SerializeField] private float _lifeTime = 1.5f;

    public override void Reset()
    {
        //여기서 해줄건 아직 없다
    }

    public void SetPositionAndPlay(Vector3 pos)
    {
        transform.position = pos;
        StartCoroutine(DelayCo());
    }

    IEnumerator DelayCo()
    {
        yield return new WaitForSeconds(_lifeTime);
        
        PoolManager.Instance.Push(this);
    }
}
