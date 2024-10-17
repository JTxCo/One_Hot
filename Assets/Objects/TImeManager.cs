using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Public reference to the hand controller object
    public GameObject rightHandReference;

    // Variable to store the position of the controller from the last frame
    private Vector3 previousRightHandPosition;

    // Threshold for movement to affect time scale
    public float movementThreshold = 0.1f;

    // Minimum and maximum time scales
    public float minTimeScale = 0.1f;
    public float maxTimeScale = 1.0f;

    void Start()
    {
        // Initialize the previous position to the current position of the right hand
        if (rightHandReference != null)
        {
            previousRightHandPosition = rightHandReference.transform.position;
        }
    }

    void Update()
    {
            // Get the distance between frames on the hand
            float distance = Vector3.Distance(previousRightHandPosition, rightHandReference.transform.position);

            // Calculate the new time scale based on the distance moved
            float newTimeScale = Mathf.Clamp(maxTimeScale - (distance / movementThreshold) * (maxTimeScale - minTimeScale), minTimeScale, maxTimeScale);

            // Set the time scale
            Time.timeScale = newTimeScale;

            // Log the time scale for debugging
            Debug.Log("Time Scale: " + Time.timeScale);

            // Don't forget to set the previous position
            previousRightHandPosition = rightHandReference.transform.position;
    }
}
