using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private Animator anim;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Break()
    {
        anim.SetBool("Break", true);
        StartCoroutine(BreakCo());
    }

    IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(.25f);
        GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
}
