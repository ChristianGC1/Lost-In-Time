using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    [SerializeField] DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    public float attackTimer;
    public bool attackOne;
    public bool attackTwo;
    public bool attackThree;

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", -1);

    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void Update()
    {
        if (dialogueUI.isOpen) return;

        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if(attackTimer <= 0)
        {
            attackTimer = 0;
        }

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack
           && currentState != PlayerState.stagger)
        {
            Debug.Log("Attack One Happened!");
            StartCoroutine(AttackCo());
            attackOne = true;
            attackTimer = 0.75f;

            if(attackTimer <= 0)
            {
                Debug.Log("Attack Timer ended in attack one!");
                attackOne = false;
            }
        }
        else if (Input.GetButtonDown("Fire1") && currentState == PlayerState.attack
           && currentState != PlayerState.stagger && attackTimer > 0 && attackOne == true)
        {
            Debug.Log("Attack Two Happened!");
            StartCoroutine(AttackCoTwo());
            attackTwo = true;
            attackOne = false;
            attackTimer = 0.75f;

            if (attackTimer <= 0)
            {
                Debug.Log("Attack Timer ended in attack two!");
                attackTwo = false;
            }
        }
        else if (Input.GetButtonDown("Fire1") && currentState == PlayerState.attack 
            && currentState != PlayerState.stagger && attackTimer > 0 && attackTwo == true)
        {
            Debug.Log("Attack Three Happened!");
            StartCoroutine(AttackCoThree());
            attackThree = true;
            attackTwo = false;
            attackTimer = 0.75f;

            if (attackTimer <= 0)
            {
                Debug.Log("Attack Timer ended in attack Three!");
                attackThree = false;
            }
        }
        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
            attackOne = false;
            attackTwo = false;
            attackThree = false;
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
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator AttackCoTwo()
    {
        anim.SetBool("IsAttackingTwo", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("IsAttackingTwo", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator AttackCoThree()
    {
        anim.SetBool("IsAttackingThree", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("IsAttackingThree", false);
        yield return new WaitForSeconds(.3f);
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
}