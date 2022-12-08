using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeSpriteOne()
    {
        anim.SetBool("GateOpen", true);
        //this.enabled = false;
    }

    public void ChangeSpriteTwo()
    {
        ItemCount.enemiesEliminated = 0;
        anim.SetBool("GateClose", true);
        anim.SetBool("GateOpen", false);
    }
}