using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;


public enum _PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}





public class SamuraiMovement : MonoBehaviour
{

    private const float MOVE_SPEED = 2f;

    public _PlayerState currentState;


    public Rigidbody2D _rigidbody2D;
    private Vector3 moveDir;
    public Animator _anim;

    private bool isDashButtonDown;
    [SerializeField]
    private float dashPower = 20f;

    private bool isAttackButtonDown;


    [Header("Attack Combo")]
    public float attackTimer;
    public float comboBufferTimer = .75f;
    public bool attackOne;
    public bool attackTwo;
    public bool attackThree;





    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        currentState = _PlayerState.idle;

        //Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (attackTimer > 0.0f)
        {
            attackTimer -= Time.deltaTime;
        }
        else if (attackTimer <= 0.0f)
        {
            ResetTimer();
        }




        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }


        moveDir = new Vector3(moveX, moveY).normalized;

        if (Input.GetButtonDown("Fire2") || (Input.GetKeyDown(KeyCode.RightAlt))) 
        {
            isDashButtonDown = true;
        }

        if (Input.GetButtonDown("Fire1") || (Input.GetKeyDown(KeyCode.Space)))
        {
            isAttackButtonDown = true;
        }

        if (currentState == _PlayerState.walk || currentState == _PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }



        if (Input.GetButtonDown("Fire1"))
        {
            if (currentState != _PlayerState.attack && currentState != _PlayerState.stagger)
            {
                Debug.Log("Attack One Happened!");
                attackOne = true;
                attackTimer = comboBufferTimer;

                StartCoroutine(AttackCo());
            }
            else if (currentState == _PlayerState.attack && currentState != _PlayerState.stagger && attackTimer > 0 && attackOne == true)
            {
                Debug.Log("Attack Two Happened!");
                attackTimer = comboBufferTimer;
                attackTwo = true;
                StartCoroutine(AttackCoTwo());
                attackOne = false;

            }
            else if (currentState == _PlayerState.attack && currentState != _PlayerState.stagger && attackTimer > 0 && attackTwo == true)
            {
                Debug.Log("Attack Three Happened!");
                StartCoroutine(AttackCoThree());
                attackTwo = false;
            }
        }

    }

    private void FixedUpdate()
    {

        _rigidbody2D.velocity = moveDir * MOVE_SPEED;


        if (isDashButtonDown)
        {
            float dashAmount = 1f;
            Vector3 dashPosition = transform.position + moveDir * dashPower;

            this.GetComponent<BoxCollider2D>().enabled = false;


            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashPower);
            if(raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }



            //_rigidbody2D.MovePosition(transform.position + moveDir * dashAmount);
            _rigidbody2D.AddForce(moveDir * dashPower * 100, ForceMode2D.Force);

            isDashButtonDown = false;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }


        if (isAttackButtonDown)
        {
            float dashAmount = 0.25f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;


            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashAmount);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }



            _rigidbody2D.MovePosition(transform.position + moveDir * dashAmount);
            isAttackButtonDown = false;
        }

    }


    void UpdateAnimationAndMove()
    {
        if (moveDir != Vector3.zero)
        {
            _anim.SetFloat("X", moveDir.x);
            _anim.SetFloat("Y", moveDir.y);
            _anim.SetBool("IsMoving", true);
        }
        else
        {
            _anim.SetBool("IsMoving", false);
        }
    }



    private IEnumerator AttackCo()
    {
        _anim.SetBool("IsAttacking", true);
        currentState = _PlayerState.attack;
        yield return null;

        _anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(0.5f);
        currentState = _PlayerState.walk;
    }

    private IEnumerator AttackCoTwo()
    {
        _anim.SetBool("IsAttackingTwo", true);
        currentState = _PlayerState.attack;
        yield return null;

        _anim.SetBool("IsAttackingTwo", false);
        yield return new WaitForSeconds(0.5f);
        currentState = _PlayerState.walk;

    }

    private IEnumerator AttackCoThree()
    {
        _anim.SetBool("IsAttackingThree", true);
        currentState = _PlayerState.attack;
        yield return null;

        _anim.SetBool("IsAttackingThree", false);
        yield return new WaitForSeconds(0.5f);
        currentState = _PlayerState.walk;

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

        _anim.SetBool("IsAttacking", false);
        _anim.SetBool("IsAttackingTwo", false);
        _anim.SetBool("IsAttackingThree", false);

        currentState = _PlayerState.walk;
    }

    public void PlayDeathAnimation()
    {
        _anim.SetBool("PlayerDeath", true);
    }
    public void PlayStaggerAnimation()
    {
        _anim.SetBool("PlayerDeath", true);
    }

}