using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxspeed = 5;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.velocity = dir.normalized * _maxspeed;
        AnimatorSet(dir);
    }

    private void AnimatorSet(Vector2 dir)
    {
        _animator.SetFloat("InputX", dir.x);
        _animator.SetFloat("InputY", dir.y);
    }
}