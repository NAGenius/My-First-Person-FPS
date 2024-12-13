using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 玩家角色的引用
    public Transform playerTransform;

    // 摄像机与玩家之间的垂直偏移量
    public float verticalOffset = 10f;

    // 摄像机与玩家之间的水平距离（在玩家后方的距离）
    public float horizontalDistance = 5f;

    // 摄像机的高度（相对于玩家的Y轴偏移）
    public float cameraHeight = 10f;

    // Update is called once per frame
    void Update()
    {
        // 如果玩家角色存在
        if (playerTransform != null)
        {
            // 获取玩家的位置和朝向
            Vector3 playerPosition = playerTransform.position;
            Vector3 playerForward = playerTransform.forward;

            // 计算摄像机的目标位置
            // 摄像机位于玩家上方，且稍微向后（根据horizontalDistance）和向上（根据cameraHeight和verticalOffset）偏移
            Vector3 cameraPosition = playerPosition + (playerForward * -horizontalDistance) + Vector3.up * cameraHeight;

            // 设置摄像机的位置
            transform.position = cameraPosition;

            // 让摄像机面向玩家（或者玩家的移动方向）
            // 这里我们让摄像机朝向玩家的位置，但你可以根据需要调整朝向逻辑
            transform.LookAt(playerPosition + Vector3.up * verticalOffset);
        }
    }
}