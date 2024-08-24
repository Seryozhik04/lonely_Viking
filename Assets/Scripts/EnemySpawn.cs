using UnityEngine;
//using System;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    //public int SpawnPeriod = 100000;

    private GameObject enemy;

    void Start()
    {
        Spawn();
        SpawnForEnemy2();
    }
    private void Update()
    {

    }

    public void Spawn()
    {
        int spawnNumber = new System.Random().Next(1, 4);
        if (spawnNumber == 1)
        {
            transform.position = Camera.main.transform.position - new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x/2 + 50, -500, 0);
        }
        else if (spawnNumber == 2)
        {
            transform.position = Camera.main.transform.position + new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x/2 + 50, 500, 0);
        }
        else
        {
            transform.position = Camera.main.transform.position + new Vector3( 0, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y/2 + 50, 0);
        }
        Instantiate(Enemy1, transform.position, Quaternion.identity);
    }
    public void SpawnForEnemy2()
    {
        transform.position = Camera.main.transform.position + new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x / 2 + 50, 600, 1);
        Instantiate(Enemy2, transform.position, Quaternion.identity);
    }
}

