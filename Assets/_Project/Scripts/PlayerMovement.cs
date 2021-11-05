using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    [SerializeField] private float durationSwordAnimation;
    [SerializeField] private float interval;
    [SerializeField] private float durationRollAnimation;
    [SerializeField] private float rollInterval;
    
    //private bool _canAttack;
    private bool _busyAttacking;
    private bool _keepAttacking;
    
    //private bool _canRoll
    private bool _busyRolling;
    private bool _keepRolling;


    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        
        HandleMovement();
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical")==-1)
            {
                animator.SetFloat("LastMoveHorizontal", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LastMoveVertical", Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Roll();
            }    
    }

   

    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        
    }

    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    private void Attack()
    {
        _keepAttacking = true;
        if (!_busyAttacking)
        {
            StartCoroutine(Attacking());
        }
    }
    private void Roll()
    {
        _keepRolling = true;
        if (!_busyRolling)
        {
            StartCoroutine(Rolling());
            
        }
    }
    
    private IEnumerator Rolling()
    {
        _busyRolling = true;
        while (_keepRolling)
        {
            
            animator.SetBool("isRolling", true);
            _busyRolling = true;
            
            yield return new WaitForSeconds(durationRollAnimation);
            _keepRolling = false;
            yield return null;
        }
        animator.SetBool("isRolling", false);
        rb.MovePosition(rb.position + movement * 15f * Time.fixedDeltaTime);
        yield return new WaitForSeconds(rollInterval);
        _busyRolling = false;
        

    }

    private IEnumerator Attacking()
    {
        _busyAttacking = true;
        while (_keepAttacking)
        {
            
            animator.SetBool("isAttacking", true);
            _busyAttacking = true;
            
            yield return new WaitForSeconds(durationSwordAnimation);
            _keepAttacking = false;
            yield return null;
        }
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(interval);
        _busyAttacking = false;
        
    }
    
}
