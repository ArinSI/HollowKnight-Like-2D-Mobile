using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour
{
    public enum State
    {
        Idle,
        Moving,
        Jumping,
        Attacking,
        GettingHit,
        Dying
    }

    public State currentState;
    public PlayerAnimationController playerAnimationController;
    public Animator animator;
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;
    public PlayerJump playerJump;
    public Rigidbody2D rb;

    void Start()
    {
        
        SetState(State.Idle); // Initial state
    }

    public void SetState(State newState)
    {
        currentState = newState;
        // Trigger the corresponding animation based on state
        switch (currentState)
        {
            case State.Idle:
                playerAnimationController.PlayIdleAnimation();
                break;
            case State.Moving:
                playerAnimationController.PlayMoveAnimation();
                break;
            case State.Jumping:
                playerAnimationController.PlayJumpAnimation();
                break;
            case State.Attacking:
                playerAnimationController.PlayAttackAnimation();
                break;
            case State.GettingHit:
                playerAnimationController.PlayGetHitAnimation();
                break;
            case State.Dying:
                playerAnimationController.PlayDieAnimation();
                break;
        }
    }

    public void IdentifyState()
    {
        // Prioritize attacking state first
        if (playerAttack.isAttacking)
        {
            SetState(State.Attacking);
            return; // Exit early to prevent further checks
        }

        // Check for jumping state
        if (!playerJump.isGrounded)
        {
            SetState(State.Jumping);
            return; // Exit early to prevent further checks
        }

        // Check for movement state
        if (!playerAttack.isAttacking && Mathf.Abs(rb.velocity.x) > 0.1f && playerJump.isGrounded)
        {
            animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
            SetState(State.Moving);
            return; // Exit early to prevent further checks
        }

        // If none of the other states are active, set to idle
        if (!playerAttack.isAttacking && Mathf.Abs(rb.velocity.x) <= 0.1f)
        {
            animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
            SetState(State.Idle);
        }
    }


}