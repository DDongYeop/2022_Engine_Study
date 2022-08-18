using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyDataSO> _spawnEnemies = null;

    private Light2D _spawnLight;
    [SerializeField] float _targetIntensity = 1.5f;

    private void Awake()
    {
        _spawnLight = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //����� �ڵ�
        {
            StartToSpawn(5);
        }
    }

    public void StartToSpawn(int count)
    {
        DOTween.To(
            () => _spawnLight.intensity,
            X => _spawnLight.intensity = X,
            _targetIntensity, 2f );
        //�������� �� ��ȯ ����
    }
}
