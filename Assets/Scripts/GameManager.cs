using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement movement;
    public float levelRestartDelay = 0;
    public GameObject menu;
    public GameObject joystic;

    public void EndGame()
    {
        movement.enabled = false;

        Invoke("RestartLevel", levelRestartDelay);
    }
    public void Conflict(bool start)
    {
        if(start == false)
        {
            menu.transform.position = Camera.main.transform.position + new Vector3(0,0,1);
            joystic.SetActive(false);
        }
        else
        {
            menu.transform.position = new Vector3(menu.transform.position.x + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x, menu.transform.position.y, 0);
            joystic.SetActive(true);
        }

    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
