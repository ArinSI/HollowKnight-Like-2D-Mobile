using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckController : MonoBehaviour
{
    public PlayerJump playerJump;
    public PlayerState playerState;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Assuming you want to check if it's a ground object
        playerJump.isGrounded = true;
        playerState.IdentifyState();
    }

}
