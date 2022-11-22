using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            other.GetComponent<Breakable>().Break();
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().GetHit();
        }
    }
}
