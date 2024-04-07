using UnityEngine;
using UnityEngine.UI;
using System;

public class PageCollection : MonoBehaviour
{
    public GameObject pageObject;
    public KeyCode collectKey = KeyCode.E;
    public string collectPrompt = "[E] Collect Page";

    public Font customFont; // Assign your font asset in the inspector

    private bool isInTrigger = false;
    private bool isPageCollected = false;
    private Text promptText;

    public event Action OnPageDisable;

    private void Start()
    {
        // Create UI Text for the prompt
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas!= null)
        {
            GameObject promptGameObject = new GameObject("PromptText");
            promptGameObject.transform.SetParent(canvas.transform);

            // Add Text component
            promptText = promptGameObject.AddComponent<Text>();
            promptText.font = customFont; // Assigning the custom font
            promptText.fontSize = 30;
            promptText.alignment = TextAnchor.MiddleCenter;

            // Set initial prompt
            promptText.text = "";
        }
        else
        {
            Debug.LogError("No Canvas found in the scene. Please create a Canvas object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            // Display prompt when player enters trigger area
            if (promptText!= null)
                promptText.text = collectPrompt;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            // Remove prompt when player exits trigger area
            if (promptText!= null)
                promptText.text = "";
        }
    }

    private void Update()
    {
        if (isInTrigger &&!isPageCollected && Input.GetKeyDown(collectKey))
        {
            // Set pageObject inactive when player presses E
            pageObject.SetActive(false);
            isPageCollected = true;
            Debug.Log("Page Collected!");

            // Clear prompt
            if (promptText!= null)
                promptText.text = "";

            // Raise the OnPageDisable event
            OnPageDisable?.Invoke();
        }
    }
}