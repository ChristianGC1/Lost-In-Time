using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int enemyDamageAmount;

    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    private void Update()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            StartCoroutine(PlayerDeath());
        }
    }
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit()
    {
        if(GetComponent<SamuraiMovement>().currentState != _PlayerState.stagger)
        {
            StartCoroutine(PlayerStagger());
            currentHealth -= enemyDamageAmount;
        }
    }
    public IEnumerator PlayerDeath()
    {
        GetComponent<SamuraiMovement>().PlayDeathAnimation();
        GetComponent<SamuraiMovement>().enabled = false;
        yield return new WaitForSeconds(1.5f);
    }

    public IEnumerator PlayerStagger()
    {
        GetComponent<SamuraiMovement>().PlayStaggerAnimation();
        GetComponent<SamuraiMovement>().currentState = _PlayerState.stagger;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SamuraiMovement>().currentState = _PlayerState.idle;
    }
}