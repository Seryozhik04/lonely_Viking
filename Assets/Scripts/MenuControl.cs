using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Slider slider;
    public void Start()
    {
        if (PlayerPrefs.HasKey("savedSliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("savedSliderValue");
        }
    }
    public void PlayPressed()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
