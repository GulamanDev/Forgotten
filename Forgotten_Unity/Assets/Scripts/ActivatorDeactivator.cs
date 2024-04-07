using UnityEngine;

public class ActivatorDeactivator : MonoBehaviour
{
    // Reference to the child object that you want to activate/deactivate
    public GameObject childObject;

    // Reference to the audio object that you want to activate/deactivate
    public GameObject audioObject;

    // Flag to track if the switch has been activated
    private bool switchActivated = false;

    void Update()
    {
        // Check if the player presses the "E" key and the switch hasn't been activated yet
        if (Input.GetKeyDown(KeyCode.E) && !switchActivated)
        {
            // Toggle the active state of the child object
            if (childObject != null)
            {
                childObject.SetActive(!childObject.activeSelf);

                // Toggle the active state of the audio object
                if (audioObject != null)
                {
                    audioObject.SetActive(!audioObject.activeSelf);
                }
                else
                {
                    Debug.LogWarning("Audio object reference is not set!");
                }

                // Set the switch activated flag to true
                switchActivated = true;
            }
            else
            {
                Debug.LogWarning("Child object reference is not set!");
            }
        }
    }
}
