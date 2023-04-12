using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator PlayerAnimation;

    public void Run()
    {
        PlayerAnimation.SetBool("isRunning", true);
        PlayerAnimation.SetBool("isShooting", false);

    }

    public void Idle()
    {
        PlayerAnimation.SetBool("isShooting", false);
        PlayerAnimation.SetBool("isRunning", false);
    }

    public void Shoot()
    {
        PlayerAnimation.SetBool("isShooting", true);
        PlayerAnimation.SetBool("isRunning", false);
    }
}
