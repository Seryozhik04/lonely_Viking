using UnityEngine;

public class GunMoving : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;

    public int gunPosition;
    public float Period = 1; // �����, ������� ������ ������ ����� ����������
    float timerFire; // ������� ���������� ������� ������ � ��������

    private void FixedUpdate()
    {
        // ����������� ������ ������ � �������
        if (gunPosition == 0)
        {
            transform.position = Player.transform.position + new Vector3(-Player.transform.localScale.x / 2, Player.transform.localScale.y / 2, 0);
        }
        else if(gunPosition == 1)
        {
            transform.position = Player.transform.position + new Vector3(0, Player.transform.localScale.y / 2, 0);
        }
        else
        {
            transform.position = Player.transform.position + new Vector3(Player.transform.localScale.x / 2, Player.transform.localScale.y / 2, 0);
        }

        // ��������
        if (Input.GetAxis("Fire1") > 0 && timerFire >= Period)

        {
            Instantiate(Bullet, this.gameObject.transform);
            timerFire = 0;
        }
        timerFire += Time.deltaTime;

    }
}
