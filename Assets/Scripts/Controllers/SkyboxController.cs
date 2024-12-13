using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public float dayDuration = 240f;

    public float currentTime = 60f;

    void Start()
    {
        UpdateSkybox();
    }

    void Update()
    {
        currentTime = (currentTime + Time.deltaTime) % dayDuration;
        UpdateSkybox();
    }

    void UpdateSkybox()
    {
        float hour = currentTime / dayDuration * 24;

        // 根据小时数切换天空盒
        if (hour >= 6 && hour < 9)
        {
            RenderSettings.skybox = skyboxMaterials[0]; // 日出
        }
        else if (hour >= 9 && hour < 17)
        {
            RenderSettings.skybox = skyboxMaterials[1]; // 白天
        }
        else if (hour >= 17 && hour < 20)
        {
            RenderSettings.skybox = skyboxMaterials[2]; // 日落
        }
        else
        {
            RenderSettings.skybox = skyboxMaterials[3]; // 夜晚
        }
    }
}