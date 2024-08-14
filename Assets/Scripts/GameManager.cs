using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
}
