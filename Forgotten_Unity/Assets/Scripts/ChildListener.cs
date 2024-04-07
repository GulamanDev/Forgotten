using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildListener : MonoBehaviour
{
    private int childCount = 0; // Initialize childCount to 0
    public int ChildCount => childCount; // Expose childCount through a property

    private void Start()
    {
        // Count the initial number of child objects
        childCount = transform.childCount;
        Debug.Log("Initial child count: " + childCount);
    }

    private void Update()
    {
        // Update the childCount variable in each frame
        UpdateChildCount();
    }

    public void UpdateChildCount()
    {
        int count = 0;

        // Count the number of active child objects
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                count++;
            }
        }

        if (count < childCount) // If a page has been deactivated
        {
            childCount = count;
            Debug.Log("Page deactivated. New child count: " + childCount);
            if (childCount == 0) // All pages are deactivated
            {
                LoadWinScene();
            }
        }
        else if (count > childCount) // If a new page has been collected
        {
            childCount = count;
            Debug.Log("New child count: " + childCount);
        }
    }

    private void LoadWinScene()
    {
        // Load the "Win" scene
        SceneManager.LoadScene("Win");
    }
}
