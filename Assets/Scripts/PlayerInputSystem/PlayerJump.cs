using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float maxJumpTime = 0.5f; // Maximum time the player can keep jumping
   
    private float jumpTimeCounter;
    public bool isJumping;
    private bool jumpKeyHeld;
    public bool isGrounded;
    public PlayerState playerState;
    public Animator animator;

    private Rigidbody2D rb;

    public PlayerAnimationController playerAnimationController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(bool isJumpingKeyPressed)
    {
        // Only allow jumping if the player is grounded
        if (isJumpingKeyPressed && isGrounded && !isJumping)
        {
            isJumping = true;
            isGrounded = false;
            playerState.IdentifyState();
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply initial jump force
            playerAnimationController.PlayJumpAnimation();
        }

        jumpKeyHeld = isJumpingKeyPressed;
    }

    void FixedUpdate()
    {
        // Handle the jump while in the air
        if (isJumping)
        {
            if (jumpKeyHeld && jumpTimeCounter > 0)
            {
                // Continue applying force while the key is held and jump time hasn't run out
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.fixedDeltaTime;
            }
            else
            {
                // End the jump
                isJumping = false;
                animator.ResetTrigger("Jump");
                
            }
        }
    }
}
