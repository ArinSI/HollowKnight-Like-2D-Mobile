using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    // Store animation hashes
    private readonly int moveHash = Animator.StringToHash("Move");
    private readonly int attackHash = Animator.StringToHash("Attack");
    private readonly int idleHash = Animator.StringToHash("Idle");
    private readonly int jumpHash = Animator.StringToHash("Jump");
    private readonly int getHitHash = Animator.StringToHash("GetHit");
    private readonly int dieHash = Animator.StringToHash("Die");

    // Animation transition duration
    public float transitionDuration = 0.1f;

    // Method to play Move animation
    public void PlayMoveAnimation()
    {
        
    }

    // Method to play Attack animation
    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    // Method to play Idle animation
    public void PlayIdleAnimation()
    {
        if (!IsPlayingAnimation(idleHash))
        {
            animator.CrossFadeInFixedTime(idleHash, transitionDuration);
        }
    }

    // Method to play Jump animation
    public void PlayJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }

    public void PlayGetHitAnimation()
    {
        if (!IsPlayingAnimation(getHitHash))
        {
            animator.CrossFadeInFixedTime(getHitHash, transitionDuration);
        }
    }

    public void PlayDieAnimation()
    {
        if (!IsPlayingAnimation(dieHash))
        {
            animator.CrossFadeInFixedTime(dieHash, transitionDuration);
        }
    }

    // Helper function to check if the given animation is currently playing
    private bool IsPlayingAnimation(int animationHash)
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0); // Get the state info of layer 0
        return currentState.shortNameHash == animationHash;
    }
}
