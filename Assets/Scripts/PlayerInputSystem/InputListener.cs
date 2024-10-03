using UnityEngine;

public class InputListener : MonoBehaviour
{
    public PlayerInputHandler playerInputHandler;

    void Update()
    {
        // Notify for left (A) or right (D) movement
        if (Input.GetKey(KeyCode.A))
        {
            playerInputHandler.HandleMovement(-1); // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerInputHandler.HandleMovement(1); // Move right
        }
        else
        {
            playerInputHandler.HandleMovement(0); // No movement
        }

        // Handle attack
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerInputHandler.HandleAttack();
        }

        // Handle jump press and release
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerInputHandler.HandleJump(true); // Start jumping
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerInputHandler.HandleJump(false); // Stop jumping
        }
    }
}
