using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public Animator anim;
    public GameObject bloodEffect;
    //public Animation _animation;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayDeathAnimation()
    {
        anim.SetBool("EnemyDeath", true);
    }

    public void PlayHitAnimation()
    {
        //_animation["EnemyHit"].wrapMode = WrapMode.Once;
        //_animation.Play("EnemyHit");
        StartCoroutine(HitCo());
    }

    public void RotateToPointer(Vector2 lookDirection)
    {
        Vector3 scale = transform.localScale;
        if (lookDirection.x > 0)
        {
            scale.x = 1;
        }
        else if (lookDirection.x < 0)
        {
            scale.x = -1;
        }
        transform.localScale = scale;
    }

    public void PlayAnimation(Vector2 movementInput)
    {
        anim.SetBool("IsMoving", movementInput.magnitude > 0);
    }

    public IEnumerator HitCo()
    {
        anim.SetBool("EnemyHit", true);
        GameObject bloodEffectIns = Instantiate(bloodEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        anim.SetBool("EnemyHit", false);
    }
}
