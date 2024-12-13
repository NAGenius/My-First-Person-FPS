using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float verticalOffset = 10f;
    public float horizontalDistance = 5f;
    public float cameraHeight = 10f;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 playerPosition = playerTransform.position;
            Vector3 playerForward = playerTransform.forward;
            Vector3 cameraPosition = playerPosition + (playerForward * -horizontalDistance) + Vector3.up * cameraHeight;
            transform.position = cameraPosition;
            transform.LookAt(playerPosition + Vector3.up * verticalOffset);
        }
    }
}