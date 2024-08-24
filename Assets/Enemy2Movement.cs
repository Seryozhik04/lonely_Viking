using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;

    private float cameraHeight;
    private float cameraWidth;
    private bool shooting = false;

    public float Period = 1; // Время, которое должно пройти между выстрелами
    private float timerFire = 3; // Сколько фактически времени прошло с выстрела
    void Start()
    {
        // Высота камеры
        cameraHeight = Camera.main.orthographicSize * 2;
        // Ширина камеры (высота / соотношение сторон)
        cameraWidth = cameraHeight * Camera.main.aspect;
        //Debug.Log("height = " +  height + "\nwidth = " + width);

        transform.Rotate(0, 0, 90);
    }

    void FixedUpdate()
    {
        if(transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).x + 100)
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.rotation.z < 0.999)
        {
            transform.Rotate(0, 0, moveSpeed*Time.deltaTime);
        }
        else
        {
            shooting = true;
        }
    }
    private void Update()
    {
        if (shooting)
        {
            if (timerFire >= Period)

            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timerFire = 0;
            }
            timerFire += Time.deltaTime;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>().SpawnForEnemy2();
            GameObject.Find("Score").GetComponent<Score>().Kill();
        }

    }
}
