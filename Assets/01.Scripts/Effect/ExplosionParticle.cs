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
        //여기서 다시 물에 넣는 것을 작생해야함
    }
}
