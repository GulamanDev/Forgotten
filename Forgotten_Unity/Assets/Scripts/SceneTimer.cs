using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    public float timerDuration = 5f; // Duration of the timer in seconds
    private bool timerRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timerDuration -= Time.deltaTime; // Decrease the timer duration

            if (timerDuration <= 0)
            {
                timerRunning = false;
            }
        }

        // Check for any button click
        if (!timerRunning && Input.anyKeyDown)
        {
            LoadMainMenu(); // Load the MainMenu scene on any button click after the timer is over
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load MainMenu scene
    }
}
