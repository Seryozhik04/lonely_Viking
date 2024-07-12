using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gm;
    public Joystick joystick;

    public float strafeSpeed = 1;

    protected bool strafeForward = false;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool strafeBack = false;
    protected Vector3 wp1;
    protected Vector3 wp2;
    protected Vector3 wp3;
    //protected Camera mainCamera = Camera.mainж
    private void Start()
    {


    wp1 = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)); // 0,1,0 // left-top
    wp2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)); // 1,1,0 // right-bottom
    wp3 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        //Debug.Log(wp1.x + "\t" + wp1.y + "\n" + wp2.x + "\t" + wp2.y);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gm.EndGame();
            Debug.Log("End game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = joystick.Vertical;
        float horizontalMove = joystick.Horizontal;

        //// Фиксация нажатий клавиш перемещения
        if (verticalMove > 0)  { strafeForward = true; }
        else  { strafeForward = false; }

        if (verticalMove < 0) {  strafeBack = true; }
        else { strafeBack = false; }

        if (horizontalMove < 0) { strafeLeft = true; }
        else { strafeLeft = false; }

        if (horizontalMove > 0) { strafeRight = true; }
        else { strafeRight = false; }


       
    }
    private void FixedUpdate()
    {
        // Перемещение
        if (strafeForward) 
        {
            rb.AddForce(transform.up * strafeSpeed, ForceMode2D.Impulse);
        }
        if (strafeBack)
        {
            rb.AddForce(-transform.up * strafeSpeed, ForceMode2D.Impulse);
        }
        if (strafeLeft)
        {
            rb.AddForce(-transform.right * strafeSpeed, ForceMode2D.Impulse);
        }
        if (strafeRight)
        {
            rb.AddForce(transform.right * strafeSpeed, ForceMode2D.Impulse);
        }

        // Ограничение перемещения в пределах экрана
        if (rb.transform.position.y > wp1.y - 40)
        {
            //Debug.Log("Верхний край = " + wp1.y);
            rb.transform.position = new Vector2(rb.transform.position.x, wp1.y - 40);
        }
        if (rb.transform.position.y < wp3.y + 20)
        {
            //Debug.Log("Нижний край = " + wp3.y);
            rb.transform.position = new Vector2(rb.transform.position.x, wp3.y + 20);
        }
        if (rb.transform.position.x > wp2.x - 40)
        {
            //Debug.Log("Правый край = " + wp2.x);
            rb.transform.position = new Vector2(wp2.x - 40, rb.transform.position.y);
        }
        if (rb.transform.position.x < wp1.x + 40)
        {
            //Debug.Log("Левый край = " + wp1.x);
            rb.transform.position = new Vector2(wp1.x + 40, rb.transform.position.y);
        }
    }
}
