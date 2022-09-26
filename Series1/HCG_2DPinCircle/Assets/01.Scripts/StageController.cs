using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private PinSpawner _pinSpawner;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Rotator _rotatorTarget;
    [SerializeField] private Rotator _rotatorIndexPanel;
    [SerializeField] private MainMenuUI _mainMenuUI;
    [SerializeField] private int _throwablePinCount;
    [SerializeField] private int _stuckPinCount;

    [SerializeField] private AudioClip _audioGameOver;
    [SerializeField] private AudioClip _audioGameClear;
    private AudioSource _audioSource;

    private Vector3 _firstTPinPosition = Vector3.down * 2;
    public float TPinDistance { private set; get; } = 1;

    private Color _failBackgroundColor = new Color(.4f, .1f, .1f);
    private Color _clearBackgroundColor = new Color(0, .5f, .25f);

    public bool isGameOver { set; get; } = false;
    public bool isGameStart { set; get; } = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _pinSpawner.Setup();

        for (int i = 0; i < _throwablePinCount; ++i)
            _pinSpawner.SpawnThrowbblePin(_firstTPinPosition + Vector3.down * TPinDistance * i, _throwablePinCount-i);

        for (int i = 0; i < _stuckPinCount; ++i)
        {
            float angle = (360 / _stuckPinCount) * i;
            _pinSpawner.SpawnStuckPin(angle, _stuckPinCount + 1 + i);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        _mainCamera.backgroundColor = _failBackgroundColor;
        _rotatorTarget.Stop();

        _audioSource.clip = _audioGameOver;
        _audioSource.Play();

        StartCoroutine(StageExit(.5f));
    }

    public void DecreaseThrowablePin()
    {
        _throwablePinCount--;

        if (_throwablePinCount == 0)
            StartCoroutine("GameClear");
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(.1f);

        if (isGameOver == true)
            yield break;

        _mainCamera.backgroundColor = _clearBackgroundColor;

        _rotatorTarget.RotateFast();
        _rotatorIndexPanel.RotateFast();

        _audioSource.clip = _audioGameClear;
        _audioSource.Play();

        StartCoroutine(StageExit(1));
    }

    private IEnumerator StageExit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        _mainMenuUI.StageExit();
    }
}
