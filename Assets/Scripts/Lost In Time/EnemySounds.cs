using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField]
    public AudioSource hit;
    public AudioClip hitc;

    public void PlayHit()
    {
        hit.PlayOneShot(hitc);
    }
}
