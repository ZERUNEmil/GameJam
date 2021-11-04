using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject shooter;
    [SerializeField] private GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, shooter.transform.position, shooter.transform.rotation);
            Bullet.transform.position = shooter.transform.position;
            Bullet.transform.position = Vector3.left;
        }
    }
}
