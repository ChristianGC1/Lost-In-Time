using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public Animator anim;
    public Animation _animation;

    public void PlayDeathAnimation()
    {
        anim.SetBool("EnemyDeath", true);
    }

    public void PlayHitAnimation()
    {
        _animation["EnemyHit"].wrapMode = WrapMode.Once;
        _animation.Play("EnemyHit");
        Debug.Log("Enemy Hit animation played");
    }
}
