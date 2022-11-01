using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private GameObject _square;
    [SerializeField] private float _moveTime = .2f;

    private StageController _stageController;

    public void Setup(StageController stageController)
    {
        this._stageController = stageController;
    }

    public void SetInPinStuckToTarget()
    {
        StopCoroutine("MoveTo");

        _square.SetActive(true);
    }

    public void MoveOneStep(float moveDistance)
    {
        StartCoroutine("MoveTo", moveDistance);
    }

    private IEnumerator MoveTo(float moveDistance)
    {
        Vector3 start = transform.position;
        Vector3 end   = transform.position + Vector3.up * moveDistance;

        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / _moveTime;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pin"))
            _stageController.GameOver();
    }
}
