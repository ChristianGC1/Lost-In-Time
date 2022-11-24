using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int playerDamageAmount;
    public BoxCollider2D c2d;

    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    private void Start()
    {
        c2d = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            StartCoroutine(EnemyDeath());
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
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= amount;
        StartCoroutine(EnemyHit());

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }
    }


    public IEnumerator EnemyDeath()
    {
        //GetComponent<EnemyAnimations>().PlayDeathAnimation();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public IEnumerator EnemyHit()
    {
        //GetComponent<EnemyAnimations>().PlayHitAnimation();
        this.c2d.enabled = false;
        //GetComponent<KnockbackFeedback>().PlayFeedback(sender);
        yield return new WaitForSeconds(0.1f);
        this.c2d.enabled = true;
    }
}
