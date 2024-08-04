using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;

    public GameObject Enemy;
    public float moveSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position; // ���������� ������� ����������� �������
        direction.z = 0f; // �� ��� �������������� �� ��� z

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+90)); // ������� ����� � ������

        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * moveSpeed); // �������� ����� � ������
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>().Spawn(); 
            Destroy(Enemy);
            GameObject.Find("Score").GetComponent<Score>().Kill();
        }

    }
}
