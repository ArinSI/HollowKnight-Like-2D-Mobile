using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAttack : MonoBehaviour
{
    public bool isAttacking = false;
    public PlayerState playerState;
    public void Attack()
    {
        isAttacking = true;
        playerState.IdentifyState();
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2.0f);
        isAttacking = false;
        playerState.IdentifyState(); 
    }
    
}
