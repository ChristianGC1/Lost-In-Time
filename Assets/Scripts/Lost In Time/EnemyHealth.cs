using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int playerDamageAmount;

    public GameObject _collider;

    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(currentHealth == 0)
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

    public void GetHit()
    {
        currentHealth -= playerDamageAmount;
        StartCoroutine(EnemyHit());
    }


    public IEnumerator EnemyDeath()
    { 
        GetComponent<EnemyAnimations>().PlayDeathAnimation();
        _collider.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    public IEnumerator EnemyHit()
    {
        GetComponent<EnemyAnimations>().PlayHitAnimation();
        //_collider.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        //_collider.GetComponent<BoxCollider2D>().enabled = true;
    }
}
