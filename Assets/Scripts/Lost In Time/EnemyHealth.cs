using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int playerDamageAmount;
    public BoxCollider2D c2d;

    public ItemCount itemCount;

    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    private void Start()
    {
        c2d = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
        itemCount = GetComponent<ItemCount>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            GetComponent<EnemyAnimations>().PlayDeathAnimation();
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
        //if (isDead)
        //    return;
        //if (sender.layer == gameObject.layer)
        //    return;

        currentHealth -= playerDamageAmount;
        GetComponent<EnemyAnimations>().PlayHitAnimation();
        //StartCoroutine(EnemyHit());

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

    public IEnumerator EnemyHit()
    {
        GetComponent<EnemyAnimations>().PlayHitAnimation();
        this.c2d.enabled = false;
        //GetComponent<KnockbackFeedback>().PlayFeedback(sender);
        yield return new WaitForSeconds(0.1f);
        this.c2d.enabled = true;
    }
}
