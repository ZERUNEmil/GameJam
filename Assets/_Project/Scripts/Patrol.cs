
using UnityEngine;
using UnityEngine.Serialization;

public class Patrol : MonoBehaviour
{
    
    [SerializeField] private GameObject exclamation;
    [SerializeField] private Animator animator;
    
    [FormerlySerializedAs("_fieldOfView")] [SerializeField] public FieldOfView fieldOfView;
    
    public float speed; 
    public float startWaitTile;
    private float waitTime;
    
    private bool isPatrolling = true;
    private bool isFollowing = false;
    
    public Transform[] moveSpots;
    
    private int spot;

    private Vector3 view;
    
    

    // Start is called before the first frame update
    void Start()
    {
        spot= 0;
        waitTime = startWaitTile;
    }

    // Update is called once per frame
    void Update() {
        if (fieldOfView.getTarget() != null) isPatrolling = false;
        if (isPatrolling) {
            Patrolling();
            isFollowing = false;
        }else 
        {
            Following();
            isFollowing = true;

        }
        
        fieldOfView.setOrigin(transform.position);
        fieldOfView.setViewDirection(view);

        if (isFollowing) {
            exclamation.SetActive(true);
        }
        else if(!isFollowing) {
            exclamation.SetActive(false);
        }
    }

    private void Following() {
        transform.position =
                Vector2.MoveTowards(transform.position, fieldOfView.getTarget().position, speed * Time.deltaTime);
    
          var angle = Vector3.SignedAngle(Vector3.down, fieldOfView.getTarget().position - transform.position, Vector3.back)+180;

              animator.SetFloat("Angle", angle);
              
              view = fieldOfView.getTarget().position - transform.position;
    
            if (waitTime <= 0) {
                fieldOfView.setTarget(null);
                waitTime = startWaitTile;
            }
            else {
                waitTime -= Time.deltaTime;
            }
            if (fieldOfView.getTarget() == null) {
                isPatrolling = true;
            }
    }
    private void Patrolling()
    {
        if (fieldOfView.getTarget() != null) isPatrolling = false;
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);
        var angle = Vector3.SignedAngle(Vector3.down, moveSpots[spot].position - transform.position, Vector3.back)+180;
       animator.SetFloat("Angle", angle);

       view = moveSpots[spot].position- transform.position;
       
        if (Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f) {
            spot += 1;
            spot %= moveSpots.Length;

        }
       
       
    }
}
