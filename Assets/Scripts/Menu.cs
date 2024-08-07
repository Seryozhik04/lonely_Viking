using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Menu : MonoBehaviour
{
    public GameManager gm;
    public GameObject continueButton;
    public Text reverseReport;

    public void ResetPressed()
    {
        gm.Conflict(true);
        gm.EndGame();
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PausePressed()
    {
        continueButton.SetActive(true);
        gm.Conflict(false);
        Time.timeScale = 0f;
    }
    public async void ContinuePressed()
    {
        continueButton.SetActive(false);
        gm.Conflict(true);
        GameObject.Find("ReverseReport").transform.position = Camera.main.transform.position + new Vector3(0, 0, 1);
        for (int i = 3; i > 0; i--)
        {
            GameObject.Find("ReverseReport").GetComponent<Text>().text = i.ToString();
            await Task.Delay(1000);
            //Thread.Sleep(1000);
        }
        GameObject.Find("ReverseReport").transform.position += Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        Time.timeScale = 1f;

    }
}
