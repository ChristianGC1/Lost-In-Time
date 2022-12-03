using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAnimation : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HealAction()
    {
        anim.SetBool("Heal", true);
        Debug.Log("HealAnimation!");
        StartCoroutine(HealAnim());
    }

    // Update is called once per frame
    public IEnumerator HealAnim()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Heal", false);
    }

    public void HealFlash()
    {
        if(anim != null)
        {
            anim.SetTrigger("HealFlash");
            Debug.Log("Flash!");
        }
    }
}
