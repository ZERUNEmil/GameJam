using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GenerateSound : MonoBehaviour
{
    [SerializeField] private Transform soundOrigin;
   
    private int x, y, z = 1;
    private Vector3 VMax = new Vector3(7,7,7);
    private Vector3 mMax = new Vector3(1,1,1);
    
    
    public PlayerMovement playerSpeed; 
   
   

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
           growSound(VMax,transform );
           playerSpeed.moveSpeed = 7;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            reduceSound(mMax, transform);
            playerSpeed.moveSpeed = 4;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D ennemy)
    {
        
        
        if (ennemy.CompareTag("Enemy"))
        {
            Debug.Log("I saw you");
            ennemy.gameObject.GetComponent<FieldOfView>().setTarget(transform);
           
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

    
    

