using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    [Header("Dialogue System")]
    [SerializeField] DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interactable?.Interact(this);
        }

        if (PlayerInputChecker.isAcceptingPlayerInput == false)
        {
            // Not accepting player input
            return;
        }

        //if (PlayerInputChecker.isAcceptingPlayerInput == false) return;
        if (dialogueUI.isOpen)
        {
            PlayerInputChecker.isAcceptingPlayerInput = false;
            //GetComponent<SamuraiMovement>().enabled = false;
        }
        if (!dialogueUI.isOpen)
        {
            PlayerInputChecker.isAcceptingPlayerInput = true;
            //GetComponent<SamuraiMovement>().enabled = true;
        }
    }
}
