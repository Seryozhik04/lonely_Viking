using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Vector3 playerPosition;
    public float bulletSpeed;

    private void Start()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerPosition = playerTransform.position + new Vector3((transform.position.x - playerTransform.position.x) / (transform.position.y - playerTransform.position.y) * -1000, -1000, 0);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * bulletSpeed); // Движение пули к игроку
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            Destroy(this.gameObject);
        }
    }
}