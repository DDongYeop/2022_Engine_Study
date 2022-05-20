using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public enum State : short
    {
        Idle = 0,
        Moving = 1,
        Charging = 2,
        Fire = 3
    }

    [Header("ĳ�� ���� ����")]
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _maxFirePower = 800f; // �ִ� ��¡��
    [SerializeField] private float _charginSpeed = 300f; //��¡ �ӵ�
    [SerializeField] private Ball _ballPrefab;

    private Transform _barrelTrm = null;
    private Transform _firePos = null;

    private float _currentRotate = 0f; //�߻簢
    private float _currentFirePower = 0f; //�߻���

    //���� ĳ���� ����
    [SerializeField] private State _state = State.Idle;

    private void Awake()
    {
        _barrelTrm = transform.Find("Barrel");
        _firePos = _barrelTrm.Find("FirePos");
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
            //���⿡ �̺�Ʈ �ڵ鸵 ����
        }

        if(Input.GetButtonUp("Jump") && _state == State.Charging)
        {
            FireCanon();
        }
    }

    private void FireCanon()
    {
        Ball ball = Instantiate(_ballPrefab, _firePos.position, Quaternion.identity) as Ball;
        ball.Fire(_firePos.right, _currentFirePower);
        //���⼭�� �̺�Ʈ �ڵ鸵
    }

    private void MandleMove()
    {
        if (_state == State.Idle || _state == State.Moving)
        {
            float y = Input.GetAxisRaw("Vertical");
            _currentRotate += y * Time.deltaTime * _rotateSpeed;
            _currentRotate = Mathf.Clamp(_currentRotate, 0f, 90f);

            _barrelTrm.rotation = Quaternion.Euler(0, 0, _currentRotate);

            #region ���� �ڵ�
            /*if (Mathf.Abs(y) > 0)
            {
                _state = State.Moving;
            }
            else
            {
                _state = State.Idle;
            }*/
            #endregion

            _state = Mathf.Abs(y) > 0 ? State.Moving : State.Idle;
        }
    }
}
