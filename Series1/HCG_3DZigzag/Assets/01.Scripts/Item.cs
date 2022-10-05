using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _itemGetEffectPrefab;
    private GameController _gameController;
    private float _rotateSpeed;

    public void Setup(GameController gameController)
    {
        this._gameController = gameController;

        _itemGetEffectPrefab =Instantiate(_itemGetEffectPrefab, transform.position, Quaternion.identity);
        _itemGetEffectPrefab.SetActive(false);
    }

    private void OnEnable()
    {
        _rotateSpeed = Random.Range(10, 100);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 0) * _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _itemGetEffectPrefab.transform.position = transform.position;
            _itemGetEffectPrefab.SetActive(true);

            _gameController.IncreseScore(5);
            gameObject.SetActive(false);
        }
    }
}
