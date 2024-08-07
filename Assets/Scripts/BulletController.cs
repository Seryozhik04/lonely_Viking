using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bullet_speed = 3.0f;
    Vector3 BulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        BulletPosition = transform.position;
    }

    private void Update()
    {
        if(transform.position.y > 2000)
        {
            Destroy(gameObject);
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =  BulletPosition + new Vector3(0, bullet_speed * Time.deltaTime, 0);
        BulletPosition = transform.position;
    }
}
