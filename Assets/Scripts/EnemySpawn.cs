using System.Collections.Generic;
using UnityEngine;
//using System;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    //public int SpawnPeriod = 100000;

    //private GameObject enemy;
    private float spawnPeriod = 0;
    private int enemy2SpawnCount = 0;
    private int enemy2que = 0;

    void Start()
    {
        Spawn();
        //SpawnForEnemy2(50);
        PlayerPrefs.SetInt("enemy2Count", 0);
        PlayerPrefs.Save();


    }
    private void Update()
    {
        // Первая очередь
        if (spawnPeriod >= 1 && enemy2SpawnCount < 5 && enemy2que == 0)
        {
            SpawnForEnemy2();
            enemy2SpawnCount++;
            spawnPeriod = 0;
        }
        else if (enemy2SpawnCount == 5 && enemy2que == 0)
        {
            enemy2que = 1;
            enemy2SpawnCount = 0;
        }
        spawnPeriod += Time.deltaTime;

        // вторая очередь
        transform.position = Camera.main.transform.position + new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x / 2 + 50, -500, 0);
        if (PlayerPrefs.GetInt("enemy2Count") == 0 && enemy2que == 1)
        {
            enemy2que = 2;
        }
        if (spawnPeriod >= 1 && enemy2SpawnCount < 5 && enemy2que == 2)
        {
            SpawnForEnemy2();
            enemy2SpawnCount++;
            spawnPeriod = 0;
        }
        else if (enemy2SpawnCount >= 5 && enemy2que == 2 && PlayerPrefs.GetInt("enemy2Count") == 0)
        {
            enemy2que = 3;
        }
        spawnPeriod += Time.deltaTime;

        if(enemy2que == 3)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame(true);
        }
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
        PlayerPrefs.SetInt("enemy2Count", PlayerPrefs.GetInt("enemy2Count") + 1);
        PlayerPrefs.Save();
    }
}

