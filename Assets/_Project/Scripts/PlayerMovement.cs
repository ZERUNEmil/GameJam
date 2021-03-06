using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float durationSwordAnimation;
    [SerializeField] private float interval;
    [SerializeField] private float rollSpeed = 15;
    [SerializeField] private LayerMask blockingLayers;
    
    public float moveSpeed = 5f;
    
    private bool _busyAttacking;
    private bool _keepAttacking;
        
    public Rigidbody2D rb;
    
    private Vector3 movement;
    private Vector3 lastLooked;
    
    public Animator animator;
    
    public float rollCooldown;
    private bool coolDown = true;
    
    private State state;
    enum State {
        walking,
        rolling
    }
    
    private void Awake()
    {
       state = State.walking;
       lastLooked = Vector3.down;
    }
    

    void Update()
    {
        switch (state)
        {
            case State.walking:
                HandleMovement();
                HandleRoll();
                if(Input.GetKeyDown(KeyCode.Mouse0)) {
                    Attack();
                }
                if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical")==-1) {
                    animator.SetFloat("LastMoveHorizontal", Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("LastMoveVertical", Input.GetAxisRaw("Vertical"));
                    lastLooked = movement;
                }
                break;
            
            case State.rolling:
                HandleRollSliding();
                break;
        }
    }
    
    private void FixedUpdate()
    {
        if (state == State.rolling) return;
        var position = rb.position;
        rb.MovePosition(Vector2.MoveTowards(position, position+(Vector2)movement, moveSpeed * Time.fixedDeltaTime));
    }
    
    private bool CanMove(Vector3 dir, float distance)
    {
        var hit = Physics2D.Raycast(transform.position, dir, distance, blockingLayers).collider;
        return hit == null;

    }
    
    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.z = 0;
        
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
    }
    
    private bool TryMove(Vector3 baseMoveDir, float distance)
    {
        movement = baseMoveDir;
        bool canMove = CanMove(movement, distance);
        if (!canMove) {
            //cannot move diagonally
            movement = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = movement.x != 0f && CanMove(movement, distance);
            if (!canMove) {
                //cannot move horizontally
                movement = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = movement.y != 0f && CanMove(movement, distance);
            }
        }
        if (canMove) {
            lastLooked = movement;
            transform.position += movement * distance;
            return true;
        }
        else {
            movement = Vector3.zero;
            return false;
        }
    }
    
    private void Attack() {
        _keepAttacking = true;
        if (!_busyAttacking) {
            StartCoroutine(Attacking());
        }
    }
   
    private IEnumerator Attacking() {
        _busyAttacking = true;
        while (_keepAttacking) {
            
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
    
    void HandleRoll() {
        if (coolDown)
        {
        if (Input.GetKey(KeyCode.Space)) {
            state = State.rolling;
                rollSpeed = 20f;
            }

        }
    }

    private void HandleRollSliding() {
        
            animator.SetBool("isRolling", true);
            TryMove(lastLooked, rollSpeed * Time.deltaTime);
            rollSpeed -= rollSpeed * 10f * Time.deltaTime;
            if (rollSpeed < 5f)
            {
                state = State.walking;
                animator.SetBool("isRolling", false);
            }
            CooldownStart();
        
    }
    
    public void CooldownStart()
    {
        StartCoroutine(CooldownCoroutine());
    }
    IEnumerator CooldownCoroutine()
    {
        coolDown = false;
        yield return new WaitForSeconds(rollCooldown);
        coolDown = true;
    }
    
}
