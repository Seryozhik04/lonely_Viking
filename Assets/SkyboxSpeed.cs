using UnityEngine;
using UnityEngine.Video;

public class SkyboxSpeed : MonoBehaviour
{
    public VideoPlayer player;
    void Start()
    {
        player.playbackSpeed = 1;
    }

    void Update()
    {
        if (Time.timeScale == 1 && player.playbackSpeed != 1)
        {
            player.playbackSpeed = 1;
        }
        if (Time.timeScale == 0 && player.playbackSpeed != 0)
        {
            player.playbackSpeed = 0;
        }
    }
}
