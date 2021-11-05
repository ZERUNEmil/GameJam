using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float delayTime;

    private void Start()
    {
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
       
        yield return new WaitForSeconds(1f);
        
    }
}
