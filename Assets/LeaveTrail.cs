using UnityEngine;

public class LeaveTrail : MonoBehaviour
{
    public float Frequence;
    public Transform[] ReturnTrail;
    private float TimeUntilPoint;
    [SerializeField] private GameObject returnSpot;
    public GameObject TrailOrigin;
    public int ReturnTrailIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeUntilPoint = Frequence;

    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilPoint -= Time.deltaTime;
        if (TimeUntilPoint <= 0)
        {
            Instantiate(returnSpot, TrailOrigin.transform.position,TrailOrigin.transform.rotation);
            if (ReturnTrailIndex == 0) ReturnTrail[ReturnTrailIndex] = returnSpot.transform;
            ReturnTrail[ReturnTrailIndex + 1] = returnSpot.transform;
            ReturnTrailIndex++;
    
            TimeUntilPoint = Frequence;
        }
        
    }
}
