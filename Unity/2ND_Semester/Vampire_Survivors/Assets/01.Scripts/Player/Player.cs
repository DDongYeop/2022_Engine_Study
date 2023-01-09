using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private readonly int IsWalk = Animator.StringToHash("iswalk");
    private float speed = .5f;
    
    private void Update() 
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var animationType = GetPlayerAnimationType(direction);
        direction *= Time.deltaTime * speed;

        transform.Translate(direction);

        spriteRenderer.flipX = direction.x < 0;

        UpdateAnimation(animationType);
    }

    private void UpdateAnimation(PlayerAnimationType animationType)
    {
        switch (animationType)
        {
            case PlayerAnimationType.Walk:
                animator.SetBool(IsWalk, true);
                break;
            default:
                animator.SetBool(IsWalk, false);
                break;
        }
    }

    private PlayerAnimationType GetPlayerAnimationType(Vector2 direction)
    {
        return direction == Vector2.zero ? PlayerAnimationType.Idle : PlayerAnimationType.Walk;
    }
}

public enum PlayerAnimationType
{
    Idle,
    Walk
}