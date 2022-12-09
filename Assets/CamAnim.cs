using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnim : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CameraZoom()
    {
        anim.SetBool("IsZooming", true);
    }

    public void BossFadeIn()
    {
        anim.SetBool("FadeIn", true);
    }

    public void BossAnimationChange()
    {
        anim.SetBool("IsLooping", true);
    }
}
