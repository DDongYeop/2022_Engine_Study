using GlobalType;
using System.Collections;
using UnityEngine;

public class CharactorController2D : MonoBehaviour
{
    public LayerMask layerMask;

    public bool below;
    public bool above;
    public bool right;
    public bool left;

    private Vector2 _moveAmount;
    private Vector2 _currentPosition;
    private Vector2 _lastPosition;

    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _capsuleCollider;

    private bool _dissbleGroundCheck;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        _lastPosition = _rigidbody.position;
        _currentPosition = _lastPosition + _moveAmount;
        _rigidbody.MovePosition(_currentPosition);
        _moveAmount = Vector2.zero;

        CheckOtherCollision();
    }

    public void Move(Vector2 movement)
    {
        _moveAmount += movement;
    }

    private void CheckOtherCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, 1, layerMask);
        if (leftHit.collider)
            left = true;
        else
            left = false;

        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, 1, layerMask);
        if (rightHit.collider)
            right = true;
        else
            right = false;

        RaycastHit2D aboveHit = Physics2D.Raycast(transform.position, Vector2.up, 1, layerMask);
        if (aboveHit.collider)
            above = true;
        else
            above = false;

        if (!_dissbleGroundCheck)
        {
            RaycastHit2D belowHit = Physics2D.Raycast(transform.position, Vector2.down, 1, layerMask);
            if (belowHit.collider)
                below = true;
            else
                below = false;
        }
    }

    public void DisableGroundCheck(float delayTime)
    {
        below = false;
        _dissbleGroundCheck = true;
        StartCoroutine(EnableGroundCheck(delayTime));
    }

    private IEnumerator EnableGroundCheck(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _dissbleGroundCheck = false;
    }
}
