using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public Transform BulletPosition;
    public float Period = 1; // ¬рем€, которое должно пройти между выстрелами
    float timerFire; // —колько фактически времени прошло с выстрела

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Input.GetAxis("Fire1") > 0 && timerFire >= Period)

        {
            Instantiate(Bullet, BulletPosition);
            timerFire = 0;
        }
        timerFire = timerFire + Time.deltaTime;
    }
}
