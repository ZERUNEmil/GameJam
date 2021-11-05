using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y);
        
    }
}
