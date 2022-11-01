using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private float _falldownTime = 2;
    private Rigidbody _rigidbody;
    private TileSpawner _tileSpawner = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Setup(TileSpawner tileSpawner)

    {
        this._tileSpawner = tileSpawner;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
            StartCoroutine(FallDownAndRespawnTile());
    }

    private IEnumerator FallDownAndRespawnTile()
    {
        yield return new WaitForSeconds(0.1f);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(_falldownTime);
        _rigidbody.isKinematic = true;

        if (_tileSpawner != null)
            _tileSpawner.SpawnTile(this.transform);
        else
            gameObject.SetActive(false);
    }
}
