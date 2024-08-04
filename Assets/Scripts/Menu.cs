using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameManager gm;

    public void ResetPressed()
    {
        gm.Conflict(true);
        gm.EndGame();
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
