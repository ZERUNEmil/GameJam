using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTime;
    public float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            Debug.Log("temps ecouele");
            SceneManager.LoadScene("GameOver");
        }
    }
}
