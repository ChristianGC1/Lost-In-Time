using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    public AudioSource step, stepTwo, swingOne, swingTwo, swingThree;
    public AudioClip stepc, stepTwoc, swingOnec, swingTwoc, swingThreec;

    public void PlayStep()
    {
        step.PlayOneShot(stepc);
    }
    public void PlayStepTwo()
    {
        stepTwo.PlayOneShot(stepTwoc);
    }
    public void PlaySwingOne()
    {
        swingOne.PlayOneShot(swingOnec);
    }

    public void PlaySwingTwo()
    {
        swingTwo.PlayOneShot(swingTwoc);
    }

    public void PlaySwingThree()
    {
        swingThree.PlayOneShot(swingThreec);
    }
}
