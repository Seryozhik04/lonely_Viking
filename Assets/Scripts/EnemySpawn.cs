using System.Threading.Tasks;
using UnityEngine;
//using System;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public int SpawnPeriod = 100000;

    void Start()
    {
        Spawn();
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
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}

