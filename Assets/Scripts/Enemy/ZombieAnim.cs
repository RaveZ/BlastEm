using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    public Animator zombieAnimation;

    public void Patrol()
    {
        zombieAnimation.SetBool("isChasing", false);
        zombieAnimation.SetBool("isAttacking", false);
        zombieAnimation.SetBool("isPatrol", true);
    }

    public void Chase()
    {
        zombieAnimation.SetBool("isAttacking", false);
        zombieAnimation.SetBool("isChasing", true);
        zombieAnimation.SetBool("isPatrol", false);
    }

    public void attack()
    {
        zombieAnimation.SetBool("isAttacking", true);
        zombieAnimation.SetBool("isChasing", false);
        zombieAnimation.SetBool("isPatrol", false);

    }
}
