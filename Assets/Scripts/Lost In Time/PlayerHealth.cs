using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    public int enemyDamageAmount;

    [SerializeField]
    public int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    private void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            GetComponent<SamuraiMovement>().PlayDeathAnimation();
        }
    }
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if(GetComponent<SamuraiMovement>().currentState != _PlayerState.stagger)
        {
            StartCoroutine(PlayerStagger());
            currentHealth -= enemyDamageAmount;
        }
        //if (isDead)
        //    return;
        //if (sender.layer == gameObject.layer)
        //    return;

        //currentHealth -= enemyDamageAmount;
        //GetComponent<EnemyAnimations>().PlayHitAnimation();

        if (currentHealth > 0)
        {
            //OnHitWithReference?.Invoke(sender);
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
        }
    }
    public IEnumerator PlayerDeath()
    {
        GetComponent<SamuraiMovement>().PlayDeathAnimation();
        GetComponent<SamuraiMovement>().enabled = false;
        GetComponent<SamuraiMovement>().currentState = _PlayerState.dead;
        yield return new WaitForSeconds(1.5f);
    }

    public IEnumerator PlayerStagger()
    {
        GetComponent<SamuraiMovement>().PlayHitAnimation();
        GetComponent<SamuraiMovement>().currentState = _PlayerState.stagger;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SamuraiMovement>().currentState = _PlayerState.idle;
    }
}
