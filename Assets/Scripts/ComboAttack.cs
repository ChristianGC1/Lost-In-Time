using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    public Animator anim;
    public int combo;
    public bool isAttacking;
    public AudioSource attackSound;
    public AudioClip[] attackClip;

    void Start()
    {
        anim = GetComponent<Animator>();
        attackSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        ComboStreak();
    }

    public void ComboStart()
    {
        isAttacking = false;
        if(combo < 3)
        {
            combo++;
        }
    }

    public void ComboStreak()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
            anim.SetTrigger("" + combo);
            attackSound.clip = attackClip[combo];
            attackSound.Play();
        }
    }

    public void ComboAttackEnd()
    {
        isAttacking = false;
        combo = 0;
    }
}
