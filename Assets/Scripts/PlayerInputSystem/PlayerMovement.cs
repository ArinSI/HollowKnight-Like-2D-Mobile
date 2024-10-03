using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Base move speed
    public float maxVelocity = 8f; // Max velocity the player can reach
    public float minVelocity = 0.1f; // Minimum velocity before stopping
    public float acceleration = 1.5f; // Acceleration rate
    public float deceleration = 2.0f; // Deceleration rate
    public GameObject PlayerModel;
    public PlayerAnimationController playerAnimationController;
    private Rigidbody2D rb;
    private float currentVelocity = 0f;
    public PlayerState playerState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Move method triggered by PlayerInputHandler
    public void Move(int direction)
    {
        if (direction != 0)
        {
            // Rotate the player model based on the direction
            if (direction < 0)
            {
                PlayerModel.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (direction > 0)
            {
                PlayerModel.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            // Increase velocity with acceleration
            currentVelocity += direction * acceleration * Time.deltaTime;
            currentVelocity = Mathf.Clamp(currentVelocity, -maxVelocity, maxVelocity);
        }
        else
        {
            // No input, apply deceleration
            if (currentVelocity > 0)
            {
                currentVelocity -= deceleration * Time.deltaTime;
                if (currentVelocity < 0)
                    currentVelocity = 0;
            }
            else if (currentVelocity < 0)
            {
                currentVelocity += deceleration * Time.deltaTime;
                if (currentVelocity > 0)
                    currentVelocity = 0;
            }
        }

        // Apply velocity to Rigidbody2D
        rb.velocity = new Vector2(currentVelocity * moveSpeed, rb.velocity.y);

        // Trigger animation and state identification
        playerState.IdentifyState();
    }
}
