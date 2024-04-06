using UnityEngine;
using UnityEngine.Video;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform slendermanTransform;
    [SerializeField] private VideoPlayer staticVideoPlayer; // Reference to the video player component
    [SerializeField] private float maxFieldOfViewAngle = 45f; // Maximum angle for the field of view

    [SerializeField] private float minOpacity = 0.2f; // Minimum opacity when Slenderman is not in the danger zone
    [SerializeField] private float maxOpacity = 1f; // Maximum opacity when Slenderman is in the full static angle

    private bool videoPlaying = false;

    private void Update()
    {
        if (playerCamera == null || slendermanTransform == null)
        {
            Debug.LogWarning("Player camera or Slenderman transform is not assigned!");
            return;
        }

        // Calculate the direction from the camera to Slenderman
        Vector3 directionToSlenderman = slendermanTransform.position - playerCamera.position;
        
        // Calculate the angle between the player's forward direction and the direction to Slenderman
        float angleToSlenderman = Vector3.Angle(playerCamera.forward, directionToSlenderman);

        // Check if Slenderman is within the camera's field of view
        if (angleToSlenderman <= maxFieldOfViewAngle)
        {
            // Slenderman is within the field of view
            Debug.Log("Slenderman detected in FOV!");
            float opacity = Mathf.Lerp(minOpacity, maxOpacity, 1f - angleToSlenderman / maxFieldOfViewAngle);
            staticVideoPlayer.targetMaterialRenderer.material.color = new Color(1f, 1f, 1f, opacity);

            if (!videoPlaying)
            {
                staticVideoPlayer.Play();
                videoPlaying = true;
            }
        }
        else
        {
            // Slenderman is outside the field of view
            Debug.Log("Slenderman not detected in FOV.");
            staticVideoPlayer.Stop();
            videoPlaying = false;
        }
    }
}
