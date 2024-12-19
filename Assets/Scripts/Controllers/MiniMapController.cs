using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
{
    public Transform player;
    public float height = 10f;
    public float followSpeed = 5f;

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, height, player.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
