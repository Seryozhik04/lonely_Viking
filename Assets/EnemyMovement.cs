using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position; // Координаты вектора направления взгляда
        direction.z = 0f; // Не даём поворачиваться по оси z

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+90)); // Поворот врага к игроку

        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * moveSpeed); // Движение врага к игроку
    }
}
