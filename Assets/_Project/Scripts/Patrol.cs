
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; 
    public Transform[] moveSpots;
    public float startWaitTile;
    private float waitTime;
    private int spot;
    private bool isPatrolling = true;
    private bool isFollowing = false;
    [SerializeField] private FieldOfView _fieldOfView;
    private Vector3 view;
    [SerializeField] private GameObject exclamation;

    [SerializeField] private Animator animator;

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
            isFollowing = false;
        }
        else 
        {
            Following();
            isFollowing = true;

        }
        _fieldOfView.setOrigin(transform.position);
        _fieldOfView.setViewDirection(view);

        if (isFollowing)
        {
            exclamation.SetActive(true);
        }
        else if(!isFollowing)
        {
            exclamation.SetActive(false);
        }
    }

    private void Following()
    {
        
            transform.position =
                Vector2.MoveTowards(transform.position, _fieldOfView.getTarget().position, speed * Time.deltaTime);
          /*  transform.rotation =
                Quaternion.LookRotation(Vector3.forward, transform.position - _fieldOfView.getTarget().position);
            */
          var angle = Vector3.SignedAngle(Vector3.down, _fieldOfView.getTarget().position - transform.position, Vector3.back)+180;

              animator.SetFloat("Angle", angle);

              view = _fieldOfView.getTarget().position - transform.position;
          

            if (waitTime <= 0)
            {
                _fieldOfView.setTarget(null);
                waitTime = startWaitTile;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }


            if (_fieldOfView.getTarget() == null)
            {
                isPatrolling = true;
            }
        

    }

    private void Patrolling()
    {
        if (_fieldOfView.getTarget() != null) isPatrolling = false;
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);
       // transform.rotation = Quaternion.LookRotation(Vector3.forward,transform.position - moveSpots[spot].position);
       var angle = Vector3.SignedAngle(Vector3.down, moveSpots[spot].position - transform.position, Vector3.back)+180;
       animator.SetFloat("Angle", angle);

       view = moveSpots[spot].position- transform.position;
       
        if (Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f)
        {
            spot += 1;
            spot %= moveSpots.Length;
        /*    if (waitTime <= 0)
            {
                spot += 1;
                spot %= moveSpots.Length;
                waitTime = startWaitTile;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            */

        }
       
       
    }
    

    private int nextSpot()
    {
        return spot++ ;
    }
    
    
    
    
}
