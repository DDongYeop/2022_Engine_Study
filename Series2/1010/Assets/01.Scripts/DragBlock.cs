using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlock : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curveMovement;

    private float _appearTime = .5f;

    public void Setup(Vector3 parnetPosition)
    {
        StartCoroutine(OnMoveTo(parnetPosition, _appearTime));
    }

    private IEnumerator OnMoveTo(Vector3 end,float time)
    {
        Vector3 start = transform.position;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.position = Vector3.Lerp(start, end, _curveMovement.Evaluate(percent));

            yield return null;
        }
    }
}
