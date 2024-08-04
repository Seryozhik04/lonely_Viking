using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myText;
    private int score = 0;
    void Update()
    {
        
    }
    public void Kill()
    {
        myText.text = (++score).ToString();
    }
}
