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
        if (dialogueUI.isOpen) return;

        if (dialogueUI.isOpen)
        {
            GetComponent<SamuraiMovement>().enabled = false;
        }
        if (!dialogueUI.isOpen)
        {
            GetComponent<SamuraiMovement>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interactable?.Interact(this);
        }
    }
}
