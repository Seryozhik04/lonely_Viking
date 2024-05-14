using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public Transform BulletPosition;
    public float Period = 1; // �����, ������� ������ ������ ����� ����������
    float timerFire; // ������� ���������� ������� ������ � ��������

    private void FixedUpdate()
    {
        if(Input.GetAxis("Fire1") > 0 && timerFire >= Period)

        {
            Instantiate(Bullet, BulletPosition);
            timerFire = 0;
        }
        timerFire = timerFire + Time.deltaTime;
    }
}
