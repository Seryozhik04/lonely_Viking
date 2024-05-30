using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gm;

    public float strafeSpeed = 1;

    protected bool strafeForward = false;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool strafeBack = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            gm.EndGame();
            Debug.Log("End game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //// Фиксация нажатий клавиш перемещения
        if (Input.GetKey("w"))  { strafeForward = true; }
        else  { strafeForward = false; }

        if (Input.GetKey("s")) {  strafeBack = true; }
        else { strafeBack = false; }

        if (Input.GetKey("a")) { strafeLeft = true; }
        else { strafeLeft = false; }

        if (Input.GetKey("d")) { strafeRight = true; }
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
        if (rb.transform.position.y > 600)
        {
            rb.transform.position = new Vector2(rb.transform.position.x, 600);
        }
        if (rb.transform.position.y < -600)
        {
            rb.transform.position = new Vector2(rb.transform.position.x, -600);
        }
        if (rb.transform.position.x > 260)
        {
            rb.transform.position = new Vector2(260, rb.transform.position.y);
        }
        if (rb.transform.position.x < -260)
        {
            rb.transform.position = new Vector2(-260, rb.transform.position.y);
        }
    }
}
