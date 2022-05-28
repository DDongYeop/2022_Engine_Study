using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanonController : MonoBehaviour
{
    public UnityEvent OnFire;
    public enum State : short
    {
        Idle = 0,
        Moving = 1,
        Charging = 2,
        Fire = 3
    }

    [Header("캐논 상태 정의")]
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _maxFirePower = 800f; // 최대 차징값
    [SerializeField] private float _charginSpeed = 300f; //차징 속도
    [SerializeField] private Ball _ballPrefab;

    [Header("캐논 UI관련")]
    [SerializeField] private CannonPanel _panel;

    [SerializeField] private CannonSoundPlayer _cannonSound;

    private Transform _barrelTrm = null;
    private Transform _firePos = null;

    private float _currentRotate = 0f; //발사각
    private float _currentFirePower = 0f; //발사함

    //현재 캐논의 상태
    [SerializeField] private State _state = State.Idle;

    private void Awake()
    {
        _barrelTrm = transform.Find("Barrel");
        _firePos = _barrelTrm.Find("FirePos");
        _cannonSound = transform.Find("CannonSound").GetComponent<CannonSoundPlayer>();
    }

    private void Update()
    {
        MandleMove();
        HandleFire();
    }

    private void HandleFire()
    {
        if(Input.GetButtonDown("Jump") && (short)_state < 2)
        {
            _state = State.Charging;
        }

        if(Input.GetButton("Jump") && _state == State.Charging)
        {
            _currentFirePower += _charginSpeed * Time.deltaTime;
            _currentFirePower = Mathf.Clamp(_currentFirePower, 0f, _maxFirePower);
            //여기에 이벤트 핸들링 들어간다
            OnChangeGauge();
        }

        if(Input.GetButtonUp("Jump") && _state == State.Charging)
        {
            _state = State.Fire;
            StartCoroutine(DelaySecond(1f));
        }
    }

    IEnumerator DelaySecond(float sec)
    {
        CameraManager.Instance.SetCannonCamActive();
        yield return new WaitForSeconds(sec);
        FireCanon();
    }

    IEnumerator DelayChageToActionCam(Transform target, float sec)
    {
        yield return new WaitForSeconds(sec);

        CameraManager.Instance.SetActionCamActive(target);

    }

    private void FireCanon()
    {
        OnFire?.Invoke(); //Null이 아닐때만 실행하라
        CameraManager.Instance.ShakeCam(2, 0.4f);
        Ball ball = Instantiate(_ballPrefab, _firePos.position, Quaternion.identity) as Ball;
        ball.Fire(_firePos.right, _currentFirePower);
        ball.OnExplosion += () =>
        {
            _cannonSound.PlayExplosionSound();
            CameraManager.Instance.ShakeCam(2, 0.6f);

            UIManager.Instance.ShowTextMessage("-계속 진행하시려면 Space bar-");

            //GameManager.Instance.BackToRigCam(1.5f);
        };

        OnChangeGauge();

        StartCoroutine(DelayChageToActionCam(ball.transform, 0.4f));
    }

    public void SetToIdle()
    {
        _state = State.Idle;
        _currentFirePower = 0; //나중에 변경해야 합니다
    }

    private void MandleMove()
    {
        if (_state == State.Idle || _state == State.Moving)
        {
            float y = Input.GetAxisRaw("Vertical");
            _currentRotate += y * Time.deltaTime * _rotateSpeed;
            _currentRotate = Mathf.Clamp(_currentRotate, 0f, 90f);

            _barrelTrm.rotation = Quaternion.Euler(0, 0, _currentRotate);

            #region 페기된 코드
            /*if (Mathf.Abs(y) > 0)
            {
                _state = State.Moving;
            }
            else
            {
                _state = State.Idle;
            }*/
            #endregion

            OnChangeAngle(); //각도가 변하면 수행한다
            _state = Mathf.Abs(y) > 0 ? State.Moving : State.Idle;
        }
    }

    private void OnChangeGauge()
    {
        //UI 갱신 코드
        _panel.SetPowerGauge(_currentFirePower / _maxFirePower);
    }

    private void OnChangeAngle()
    {
        _panel.SetTextAngle(_currentRotate);
    }
}
