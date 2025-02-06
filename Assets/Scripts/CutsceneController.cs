using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign this in the Inspector
    public string nextSceneName; // Set this in the Inspector

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // Detect when the video finishes
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}
