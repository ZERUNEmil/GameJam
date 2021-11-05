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
    
    //private bool _canAttack;
    private bool _busyAttacking;
    private bool _keepAttacking;


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
