using System.Threading.Tasks;
using UnityEngine;

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
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}

