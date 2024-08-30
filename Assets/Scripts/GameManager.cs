using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public PlayerMovement movement;
    public float levelRestartDelay = 0;
    //public GameObject menu;
    public GameObject mainCanvas;
    public GameObject menuCanvas;
    public GameObject score;

    private int recordScore;

    private void Start()
    {
        //PlayerPrefs.SetInt("SavedScore", 0);
        //PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("enemy2SpawnDistance"))
        {
            PlayerPrefs.DeleteKey("enemy2SpawnDistance");
        }
        PlayerPrefs.Save();

        if (PlayerPrefs.HasKey("SavedScore"))
        {
            recordScore = PlayerPrefs.GetInt("SavedScore");
        }
        else recordScore = 0;
        GameObject.Find("RecordScore").GetComponent<Text>().text = "Record Score: " + recordScore;
        Time.timeScale = 1f;
    }
    public void EndGame()
    {
        movement.enabled = false; 
        Invoke("RestartLevel", levelRestartDelay);
        Time.timeScale = 1f;
    }
    public void Conflict(bool start)
    {
        if(start == false)
        {
            menuCanvas.transform.position = Camera.main.transform.position + new Vector3(0,0,1);
            mainCanvas.SetActive(false);

            int scoreInt = System.Int32.Parse(score.GetComponent<Text>().text);
            if (scoreInt > recordScore)
            {
                recordScore = scoreInt;
                GameObject.Find("RecordScore").GetComponent<Text>().text = "Record Score: " + recordScore;
                PlayerPrefs.SetInt("SavedScore", recordScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            menuCanvas.transform.position = new Vector3(menuCanvas.transform.position.x + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x, menuCanvas.transform.position.y, 0);
            mainCanvas.SetActive(true);
        }

    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public async void EndGame(bool end)
    {
        //movement.enabled = false;
        Time.timeScale = 0f;
        GameObject.Find("ReverseReport").transform.position = Camera.main.transform.position + new Vector3(0, 0, 1);
        GameObject.Find("ReverseReport").GetComponent<Text>().text = "You\n Win!";
        GameObject.Find("ReverseReport").GetComponent<Text>().fontSize = 50;
        await Task.Delay(5000);
        SceneManager.LoadScene("MainMenu");
    }
}
