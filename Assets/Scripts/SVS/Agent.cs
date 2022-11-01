using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Agent : MonoBehaviour
{
    private AgentAnimations playerAnimations;
    private AgentMover playerMover;

    private WeaponParent weaponParent;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Awake()
    {
        playerAnimations = GetComponentInChildren<AgentAnimations>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        playerMover = GetComponent<AgentMover>();
    }

    private void Update()
    {
        //pointerInput = GetPointerInput();
        //movementInput = movement.action.ReadValue<Vector2>().normalized;

        playerMover.MovementInput = movementInput;
        weaponParent.PointerPosition = pointerInput;
        AnimateCharacter();
    }

    public void PerformAttack()
    {
        weaponParent.Attack();
    }

    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        playerAnimations.RotateToPointer(lookDirection);
        playerAnimations.PlayAnimation(movementInput);
    }
}
