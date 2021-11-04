using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; 
    public Transform[] moveSpots;
    public float startWaitTile;
    private float waitTime;
    private int spot;

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
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);
        
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
        _fieldOfView.setOrigin(transform.position);
        _fieldOfView.setViewDirection(transform.forward);
    }

    private int nextSpot()
    {
        return spot++ ;
    }
}
