using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;

    void Start()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
