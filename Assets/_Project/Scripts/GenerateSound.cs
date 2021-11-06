using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GenerateSound : MonoBehaviour
{
    [SerializeField] private Transform soundOrigin;
   
   
    private Vector3 VMax = new Vector3(7,7,7);
    private Vector3 mMax = new Vector3(1,1,1);
    [SerializeField] private Animator anim;
    
    public PlayerMovement playerSpeed; 
   
   

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
           growSound(VMax,transform );
           playerSpeed.moveSpeed = 6;
           anim.SetFloat("Speed", 6);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            reduceSound(mMax, transform);
            playerSpeed.moveSpeed = 2;
            anim.SetFloat("Speed", 2);
        }
        
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

    
    

