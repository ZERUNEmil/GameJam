using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;
using System.Collections;

public class GenerateSound : MonoBehaviour
{
    [SerializeField] private Transform soundOrigin;
   
   
    private Vector3 VMax = new Vector3(7,7,7);
    private Vector3 mMax = new Vector3(1,1,1);
    [SerializeField] private Animator anim;
    private bool toggleSpeed = false;
    
    public PlayerMovement playerSpeed; 
    public float sneakCooldown = 0.5f;
    private bool coolDown = true;
   

    void FixedUpdate()
    {
        if (coolDown)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                toggleSpeed = !toggleSpeed;
                if (toggleSpeed)
                {
                    growSound(VMax, transform);
                    playerSpeed.moveSpeed = 6;
                    anim.SetFloat("Speed", 6);
                    CooldownStart();
                }
                //if (Input.GetKey(KeyCode.LeftControl))
                else
                {
                    reduceSound(mMax, transform);
                    playerSpeed.moveSpeed = 2;
                    anim.SetFloat("Speed", 2);
                    CooldownStart();
                }
            }
        }

    }
    
    public void CooldownStart()
    {
        StartCoroutine(CooldownCoroutine());
    }
    IEnumerator CooldownCoroutine()
    {
        coolDown = false;
        yield return new WaitForSeconds(sneakCooldown);
        coolDown = true;
    }

    private void OnTriggerEnter2D(Collider2D ennemy)
    {
        
        
        if (ennemy.CompareTag("Enemy"))
        {
            Debug.Log(ennemy.gameObject.name);
            Debug.Log("I saw you");
            ennemy.gameObject.GetComponent<Patrol>()._fieldOfView.setTarget(transform);

        }
    }

    public void growSound(Vector3 size, Transform origin)
    {
       
            origin.localScale = size;
        
    }
    
    public void reduceSound(Vector3 size, Transform origin)
    {
        origin.localScale = size;
    }
    }

    
    

