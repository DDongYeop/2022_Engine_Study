using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField] private StageController _stageController;
    [SerializeField] private GameObject _pinPrefab;
    [SerializeField] private GameObject _textPinIndexPrefab;
    [SerializeField] private Transform _textParent;

    [Header("Stuck Pin")]
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _targetPosition = Vector3.up * 2;
    [SerializeField] private float _targetRadius = 0.8f;
    [SerializeField] private float _pinLegth = 1.5f;

    [Header("Throwble Pin")]
    [SerializeField] private float _bottomAngle = 270;
    private List<Pin> _throwablePins;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Setup()
    {
        _throwablePins = new List<Pin>();
    }

    private void Update()
    {
        if (_stageController.isGameStart == false || _stageController.isGameOver == true)
            return;

        if (Input.GetMouseButtonDown(0) && _throwablePins.Count > 0)
        {
            SetInPinStruckToTarget(_throwablePins[0].transform, _bottomAngle);
            _throwablePins.RemoveAt(0);

            for (int i = 0; i < _throwablePins.Count; ++i)
                _throwablePins[i].MoveOneStep(_stageController.TPinDistance);

            _stageController.DecreaseThrowablePin();

            _audioSource.Play();
        }
    }

    public void SpawnThrowbblePin(Vector3 position, int index)
    {
        GameObject clone = Instantiate(_pinPrefab, position, Quaternion.identity);
        
        Pin pin = clone.GetComponent<Pin>();
        pin.Setup(_stageController);

        _throwablePins.Add(pin);

        SpawnTextUI(clone.transform, index);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        GameObject clone = Instantiate(_pinPrefab);

        Pin pin = clone.GetComponent<Pin>();
        pin.Setup(_stageController);

        SetInPinStruckToTarget(clone.transform, angle);
        
        SpawnTextUI(clone.transform, index);
    }

    private void SetInPinStruckToTarget(Transform pin, float angle)
    {
        pin.position = Utils.GetPositionFromAngle(_targetRadius + _pinLegth, angle) + _targetPosition;
        pin.rotation = Quaternion.Euler(0, 0, angle);
        pin.SetParent(_targetTransform);
        pin.GetComponent<Pin>().SetInPinStuckToTarget();
    }

    private void SpawnTextUI(Transform target, int index)
    {
        GameObject textClone = Instantiate(_textPinIndexPrefab);
        textClone.transform.SetParent(_textParent);
        textClone.transform.localScale = Vector3.one;
        textClone.GetComponent<WorldToScrennPosition>().Setup(target);
        textClone.GetComponent<TMPro.TextMeshProUGUI>().text = index.ToString();
    }
}
