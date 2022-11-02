using GlobalType;
using System.Collections;
using UnityEngine;

public class CharactorController2D : MonoBehaviour
{
    public float raycastDistance = 0.2f;
    public LayerMask layerMask;
    public float slopAngleLimit = 45f;

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
        RaycastHit2D leftHit = Physics2D.BoxCast(_capsuleCollider.bounds.center, _capsuleCollider.size * 0.7f, 0f, Vector2.left, raycastDistance, layerMask);

        if (leftHit.collider)
            left = true;
        else
            left = false;

        RaycastHit2D rightHit = Physics2D.BoxCast(_capsuleCollider.bounds.center, _capsuleCollider.size * 0.7f, 0f, Vector2.right, raycastDistance, layerMask);
        if (rightHit.collider)
            right = true;
        else
            right = false;

        RaycastHit2D aboveHit = Physics2D.CapsuleCast(_capsuleCollider.bounds.center, _capsuleCollider.size, CapsuleDirection2D.Vertical, 0f, Vector2.up, raycastDistance, layerMask);
        if (aboveHit.collider)
            above = true;
        else
            above = false;

        if (!_dissbleGroundCheck)
        {
            RaycastHit2D hit = Physics2D.CapsuleCast(_capsuleCollider.bounds.center, _capsuleCollider.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, raycastDistance, layerMask);
            if (hit.collider)
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