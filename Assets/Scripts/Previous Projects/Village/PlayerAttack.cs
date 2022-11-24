using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private bool hasRecentlyHitAnotherCollider2D = false;
    [SerializeField] private Collider2D recentlyHitCollider;
    [SerializeField] private float collisionResetCountdown = 0.1f;

    private void Update()
    {
        if(hasRecentlyHitAnotherCollider2D == true)
        {
            collisionResetCountdown -= Time.deltaTime;

            if(collisionResetCountdown < 0)
            {
                Debug.LogWarning("WE HAVE RESET THE TIMER -- Called from [" + gameObject.name + "].");
                hasRecentlyHitAnotherCollider2D = false;
                recentlyHitCollider = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("ON TRIGGER ENTER 2D BEGIN -- Called from [" + gameObject.name + "].");

        if (hasRecentlyHitAnotherCollider2D == true)
        {
            Debug.LogWarning("We HAVE recently hit another collider. RETURN and exit from this method.");
            Debug.LogWarning("ON TRIGGER ENTER 2D END -- Called from [" + gameObject.name + "].");
            return;
        }

        Debug.LogWarning("We have not recently hit another collider... so, let's collide!");

        recentlyHitCollider = other;
        hasRecentlyHitAnotherCollider2D = true;
        collisionResetCountdown = 0.1f;

        if (recentlyHitCollider.CompareTag("Breakable"))
        {
            Debug.Log("Player character has hit a BREAKABLE object: [" + recentlyHitCollider.gameObject.name + "].");
            recentlyHitCollider.GetComponent<Breakable>().Break();
        }

        if (recentlyHitCollider.CompareTag("Enemy"))
        {
            Debug.Log("Player character has hit an ENEMY: [" + recentlyHitCollider.gameObject.name + "].");
            recentlyHitCollider.GetComponent<EnemyHealth>().GetHit(5, null);
        }

        Debug.LogWarning("ON TRIGGER ENTER 2D END -- Called from [" + gameObject.name + "].");
    }
}
