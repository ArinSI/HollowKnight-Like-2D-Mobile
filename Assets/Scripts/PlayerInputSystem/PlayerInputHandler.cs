using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerJump playerJump;
    public PlayerAttack playerAttack;

    public void HandleMovement(int direction)
    {
        playerMovement.Move(direction);
    }

    public void HandleAttack()
    {
        Debug.Log("Attack key pressed");
        playerAttack.Attack();
    }

    public void HandleJump(bool isJumping)
    {
        playerJump.Jump(isJumping);
    }
}
