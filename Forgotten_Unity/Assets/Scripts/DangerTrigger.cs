using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DangerTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public float maxVolume = 1.0f;
    public float fadeSpeed = 0.5f;
    public float maxTriggerTime = 2.5f; // Maximum time Slenderman can stay in trigger

    private bool isSlendermanInside = false;
    private float timeInside = 0f;

    private void Start()
    {
        // Initialize volume to 0.1
        videoPlayer.SetDirectAudioVolume(0, 0.1f);
    }

    private void Update()
    {
        // Adjust volume based on how long Slenderman is in the trigger
        if (isSlendermanInside)
        {
            timeInside += Time.deltaTime;
            float currentVolume = Mathf.Clamp01(timeInside * fadeSpeed);
            SetVideoVolume(currentVolume);

            // Check if Slenderman has stayed in trigger for too long
            if (timeInside >= maxTriggerTime)
            {
                LoadGameOverScene();
            }
        }
        else
        {
            timeInside = 0f;
            SetVideoVolume(0.1f); // Set volume back to 0.1 when Slenderman is not inside
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slenderman"))
        {
            Debug.Log("Danger!");
            isSlendermanInside = true;
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slenderman"))
        {
            isSlendermanInside = false;
            videoPlayer.Stop();
            videoPlayer.gameObject.SetActive(false);
        }
    }

    private void SetVideoVolume(float opacity)
    {
        // Increase volume gradually from 0.1 to 1 based on opacity
        float volume = Mathf.Lerp(0.1f, maxVolume, opacity);
        videoPlayer.SetDirectAudioVolume(0, volume);
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
