
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; 
    public Transform[] moveSpots;
    public float startWaitTile;
    private float waitTime;
    private int spot;
    private bool isPatrolling = true; 

    [SerializeField] private FieldOfView _fieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        spot= 0;
        waitTime = startWaitTile;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fieldOfView.getTarget() != null) isPatrolling = false;
        if (isPatrolling)
        {
            Patrolling();
        }
        else
        {
            Following();
        }
        
        _fieldOfView.setOrigin(transform.position);
        _fieldOfView.setViewDirection(-transform.up);
        
    }

    private void Following()
    {
        if(_fieldOfView.getTarget() == null) return;
        transform.position =
            Vector2.MoveTowards(transform.position, _fieldOfView.getTarget().position, speed * Time.deltaTime);
        transform.rotation =
            Quaternion.LookRotation(Vector3.forward, transform.position - _fieldOfView.getTarget().position);
        if (Vector2.Distance(transform.position, _fieldOfView.getTarget().position) < 0.2f)
        {
            isPatrolling = true;
        }
    }

    private void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward,transform.position - moveSpots[spot].position);
        if (Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                spot += 1;
                spot %= moveSpots.Length;
                waitTime = startWaitTile;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
       
       
    }
    

    private int nextSpot()
    {
        return spot++ ;
    }
    
    
    
    
}
