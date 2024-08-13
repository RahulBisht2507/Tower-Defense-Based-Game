using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to the player GameObject

    [SerializeField]private float height = 10.0f; // Height of the camera above the target
    [SerializeField]private float distance = 10.0f; // Distance from the target

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No target found for the camera!");
            return;
        }

        // Calculate camera position based on target position
        Vector3 newPosition = target.position - (Vector3.forward * distance) + (Vector3.up * height);

        // Set the new position for the camera
        transform.position = newPosition;

        // Make the camera look at the target
        transform.LookAt(target.position);
    }
}
