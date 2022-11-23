using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum _EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Agent : MonoBehaviour
{
    private AgentAnimations playerAnimations;
    private AgentMover playerMover;

    private WeaponParent weaponParent;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    [Header("Animator")]
    public Animator anim;

    [Header("State Machine")]
    public _EnemyState currentState;

    private void Awake()
    {
        playerAnimations = GetComponentInChildren<AgentAnimations>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        playerMover = GetComponent<AgentMover>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //pointerInput = GetPointerInput();
        //movementInput = movement.action.ReadValue<Vector2>().normalized;

        playerMover.MovementInput = movementInput;
        //weaponParent.PointerPosition = pointerInput;
        //AnimateCharacter();
    }

    private void FixedUpdate()
    {
        changeAnim(MovementInput);
    }

    public void PerformAttack()
    {
        //weaponParent.Attack();
        StartCoroutine(AttackCo());
    }

    private void AnimateCharacter()
    {
        //Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        //playerAnimations.RotateToPointer(lookDirection);
        //playerAnimations.PlayAnimation(movementInput);
    }

    public void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("X", setVector.x);
        anim.SetFloat("Y", setVector.y);
    }

    public void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    public void ChangeState(_EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public IEnumerator AttackCo()
    {
        currentState = _EnemyState.attack;
        anim.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(1f);
        currentState = _EnemyState.walk;
        anim.SetBool("IsAttacking", false);
    }
}
