using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float strafeSpeed = 1;

    protected bool strafeForward = false;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool strafeBack = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))  { strafeForward = true; }
        else  { strafeForward = false; }

        if (Input.GetKey("s")) {  strafeBack = true; }
        else { strafeBack = false; }

        if (Input.GetKey("a")) { strafeLeft = true; }
        else { strafeLeft = false; }

        if (Input.GetKey("d")) { strafeRight = true; }
        else { strafeRight = false; }

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
    private void FixedUpdate()
    {
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
    }
}
