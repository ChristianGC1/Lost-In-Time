using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class HeroControl : MonoBehaviour
{
    public PlayerState currentState;

    [Header("Dialogue System")]
    [SerializeField] DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    [Header("Attack Push")]
    //[SerializeField] private float strength = 16;
    //[SerializeField] private float delay = 0.15f;

    [Header("Attack Combo")]
    public float attackTimer;
    public float comboBufferTimer = .75f;
    public bool attackOne;
    public bool attackTwo;
    public bool attackThree;

    [Header("Player Movement")]
    public float speed;
    private Vector3 change;

    [Header("Player Components")]
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //anim.SetFloat("X", 0);
        //anim.SetFloat("Y", -1);

        //Set Cursor to not be visible
        Cursor.visible = false;

    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void Update()
    {
        if (dialogueUI.isOpen) return;

        if(attackTimer > 0.0f)
        {
            attackTimer -= Time.deltaTime;
        }
        else if(attackTimer <= 0.0f)
        {
            ResetTimer();
        }

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.stagger)
            {
                //ForwardAttack();
                Debug.Log("Attack One Happened!");
                attackOne = true;
                attackTimer = comboBufferTimer;

                StartCoroutine(AttackCo());
            }
            else if (currentState == PlayerState.attack && currentState != PlayerState.stagger && attackTimer > 0 && attackOne == true)
            {
                Debug.Log("Attack Two Happened!");
                attackTimer = comboBufferTimer;
                attackTwo = true;
                StartCoroutine(AttackCoTwo());
                attackOne = false;

            }
            else if (currentState == PlayerState.attack && currentState != PlayerState.stagger && attackTimer > 0 && attackTwo == true)
            {
                Debug.Log("Attack Three Happened!");
                StartCoroutine(AttackCoThree());
                attackTwo = false;
            }
        }


        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interactable?.Interact(this);
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("IsAttacking", true);
        currentState = PlayerState.attack;
        yield return null;

        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(0.5f);
        currentState = PlayerState.walk;
    }

    private IEnumerator AttackCoTwo()
    {
        anim.SetBool("IsAttackingTwo", true);
        currentState = PlayerState.attack;
        yield return null;

        anim.SetBool("IsAttackingTwo", false);
        yield return new WaitForSeconds(0.5f);
        currentState = PlayerState.walk;

    }

    private IEnumerator AttackCoThree()
    {
        anim.SetBool("IsAttackingThree", true);
        currentState = PlayerState.attack;
        yield return null;

        anim.SetBool("IsAttackingThree", false);
        yield return new WaitForSeconds(0.5f);
        currentState = PlayerState.walk;

    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            anim.SetFloat("X", change.x);
            anim.SetFloat("Y", change.y);
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        rb.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    private void ResetTimer()
    {
        attackTimer = 0.0f;
        if (attackOne == true)
        {
            Debug.Log("Exiting Attack One!");
        }
        else if (attackTwo == true)
        {
            Debug.Log("Exiting Attack Two!");
        }
        else if (attackThree == true)
        {
            Debug.Log("Exiting Attack Three!");
        }
        attackOne = false;
        attackTwo = false;
        attackThree = false;

        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsAttackingTwo", false);
        anim.SetBool("IsAttackingThree", false);

        currentState = PlayerState.walk;
    }

    // Forward Push for Attacks needs work
    //public void ForwardAttack()
    //{
    //    Vector2 direction = (transform.position * strength * Time.deltaTime).normalized;

    //    rb.AddForce(direction * strength, ForceMode2D.Impulse);
    //}
}