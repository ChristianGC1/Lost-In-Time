using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public DialogueUI dialogueStart;

    public GameObject mainCamera;

    public LevelChanger changer;

    private void Start()
    {
        PlayerSleepAnimation();
    }

    private void Update()
    {
        if(dialogueStart.isOpen == false)
        {
            GetComponent<SamuraiMovement>()._anim.SetBool("IsSleeping", false);
            StartCoroutine(PlayerWakeUp());
        }
    }

    public void PlayerSleepAnimation()
    {
        GetComponent<SamuraiMovement>()._anim.SetBool("IsSleeping", true);
    }
    public IEnumerator PlayerWakeUp()
    {
        GetComponent<SamuraiMovement>()._anim.SetBool("WakeUp", true);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SamuraiMovement>()._anim.SetBool("WakeUp", false);
        Debug.Log("Wake up false!");
        //GetComponent<CamAnim>().CameraZoom();
        changer.LoadLevel();
        yield return null;
    }
}
