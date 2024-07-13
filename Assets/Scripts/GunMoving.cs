using UnityEngine;

public class GunMoving : MonoBehaviour
{
    public GameObject Player;

    private void FixedUpdate()
    {
        transform.position = Player.transform.position + new Vector3(Player.transform.localScale.x/2, Player.transform.localScale.y/2, 0);
    }
}
