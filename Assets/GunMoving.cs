using UnityEngine;

public class GunMoving : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = Player.transform.position + new Vector3(0,3,0);
    }
}
