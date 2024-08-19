using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LightModifier : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;
    
    public Color dayCloudColor;
    public Color nightCloudColor;
    
    public Color dayGroundColor;
    public Color nightGroundColor;
    
    public Color dayLightColor;
    public Color nightLightColor;
    
    public float dayLightIntensity = 1;
    public float nightLightIntensity = .45f;

    private Color currentColor;
    private Color currentCloudColor;
    private Color currentGroundColor;
    private Color currentLightColor;
    private float currentLightIntensity;
    public bool isDayTime = true;

    public GameObject Moon;
    public Vector3 MoonDownPosition;
    public Vector3 MoonUpPosition;
    
    public Material cloudsMat;
    public GameObject cloud;

    public GameObject StandingGuard;
    public GameObject SleepingGuard;

    public Light directionalLight;




    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetColor("_SkyTint", dayColor);
        RenderSettings.skybox.SetColor("_GroundColor", dayGroundColor);
        RenderSettings.ambientIntensity = dayLightIntensity;
        cloudsMat = cloud.GetComponent<MeshRenderer>().sharedMaterial;
        cloudsMat.SetColor("_AlbedoColor", dayCloudColor);
        directionalLight.color = dayLightColor;
    }

   
    //Set Color directly and instantly 
    public void SetCamsDayTime(Color color)
    {
        //Iterate through each camera in the scene and turn background to solid color
        foreach (Camera c in GetAllCams())
        {
            c.clearFlags = CameraClearFlags.SolidColor;
            c.backgroundColor = color;
            currentColor = c.backgroundColor;
            currentCloudColor = cloudsMat.GetColor("_AlbedoColor");
            currentLightColor = directionalLight.color;
        }


    }

    public void SetNight()
    {
        //Iterate through each camera in the scene and turn background to solid color
        foreach (Camera c in GetAllCams())
        {
            c.clearFlags = CameraClearFlags.SolidColor;
            c.backgroundColor = nightColor;
            RenderSettings.skybox.SetColor("_SkyTint", nightColor);
            RenderSettings.skybox.SetColor("_GroundColor", nightGroundColor);
            RenderSettings.ambientIntensity = nightLightIntensity;
            cloudsMat.SetColor("_AlbedoColor", nightCloudColor);
            directionalLight.color = nightLightColor;
            currentColor = RenderSettings.skybox.GetColor("_SkyTint");
            currentLightColor = directionalLight.color;
            currentGroundColor = RenderSettings.skybox.GetColor("_GroundColor");
            currentCloudColor = cloudsMat.GetColor("_AlbedoColor");
            currentLightIntensity = RenderSettings.ambientIntensity;
            isDayTime = false;
        }
    }

    public void SetDay()
    {
        //Iterate through each camera in the scene and turn background to solid color
        foreach (Camera c in GetAllCams())
        {
            c.clearFlags = CameraClearFlags.SolidColor;
            c.backgroundColor = dayColor;
            RenderSettings.skybox.SetColor("_SkyTint", dayColor);
            RenderSettings.skybox.SetColor("_GroundColor", dayGroundColor);
            RenderSettings.ambientIntensity = dayLightIntensity;
            cloudsMat.SetColor("_AlbedoColor", dayCloudColor);
            directionalLight.color = nightLightColor;
            currentColor = RenderSettings.skybox.GetColor("_SkyTint");
            currentGroundColor = RenderSettings.skybox.GetColor("_GroundColor");
            currentCloudColor = cloudsMat.GetColor("_AlbedoColor");
            currentLightIntensity = RenderSettings.ambientIntensity;
            currentLightColor = directionalLight.color;
            isDayTime = true;
        }
    }

    //Gets all cameras in the scene
    public Camera[] GetAllCams()
    {
        // Find all objects of type Camera and cast them to an array of Camera
        Camera[] cameras = FindObjectsOfType<Camera>();
        //Debug.Log("Total Cameras Found " +  cameras.Length);

        // Return the array of cameras
        return cameras;
    }

    void GetBackgroundColor()
    {
        foreach (Camera c in GetAllCams())
        {
            currentColor = RenderSettings.skybox.GetColor("_SkyTint");
            currentGroundColor = RenderSettings.skybox.GetColor("_GroundColor");
            currentCloudColor = cloudsMat.GetColor("_AlbedoColor");
            currentLightIntensity = RenderSettings.ambientIntensity;
            currentLightColor = directionalLight.color;
        }
    }

    public void FadeToColor(bool day = true, float duration = 0)
    {
        SleepingGuard.SetActive(true);
        StandingGuard.SetActive(false);
        GetBackgroundColor();
        StartCoroutine(FadeBetweenColors(day, duration));
    }

    private IEnumerator FadeBetweenColors(bool day = true, float duration = 0)
    {
        float elapsedTime = 0f;

        if(day) //Going to day time
        {
            while (elapsedTime < duration)
            {
                // Calculate the current color based on the elapsed time
                Color _currentColor = Color.Lerp(currentColor, dayColor, elapsedTime / duration);
                Color _currentCloudColor = Color.Lerp(currentCloudColor, dayCloudColor, elapsedTime / duration);
                Color _currentGroundColor = Color.Lerp(currentGroundColor, dayGroundColor, elapsedTime / duration);
                Color _currentLightColor = Color.Lerp(currentLightColor, dayLightColor, elapsedTime / duration);
                float _currentLightIntensity = Mathf.Lerp(currentLightIntensity, dayLightIntensity, elapsedTime / duration);
                isDayTime = true;
                // Set the background color for all cameras
                foreach (Camera c in GetAllCams())
                {
                  //  currentColor = c.backgroundColor;
                    currentColor = RenderSettings.skybox.GetColor("_SkyTint");
                    currentLightColor = directionalLight.color;
                    currentGroundColor = RenderSettings.skybox.GetColor("_GroundColor");
                    currentCloudColor = cloudsMat.GetColor("_AlbedoColor");
                    currentLightIntensity = RenderSettings.ambientIntensity;
                   // c.clearFlags = CameraClearFlags.SolidColor;
                   // c.backgroundColor = _currentColor;
                   RenderSettings.skybox.SetColor("_SkyTint", _currentColor);
                   RenderSettings.skybox.SetColor("_GroundColor", _currentGroundColor);
                   RenderSettings.ambientIntensity = _currentLightIntensity;
                   cloudsMat.SetColor("_AlbedoColor", _currentCloudColor);
                   directionalLight.color = _currentLightColor;
                    currentColor = RenderSettings.skybox.GetColor("_SkyTint");
                    currentLightColor = directionalLight.color;
                    currentGroundColor = RenderSettings.skybox.GetColor("_GroundColor");
                    currentCloudColor = cloudsMat.GetColor("_AlbedoColor");
                    currentLightIntensity = RenderSettings.ambientIntensity;
                }

                // Increase the elapsed time
                elapsedTime += Time.deltaTime;

                // Wait for the next frame
                yield return null;
            }
        }
        else //if going to night time
        {
            while (elapsedTime < duration)
            {
                Moon.transform.position = Vector3.Lerp(MoonDownPosition,MoonUpPosition, elapsedTime / duration);

                isDayTime = false;


                // Calculate the current color based on the elapsed time
                Color _currentColor = Color.Lerp(currentColor, nightColor, elapsedTime / duration);
                Color _currentCloudColor = Color.Lerp(currentCloudColor, nightCloudColor, elapsedTime / duration);
                Color _currentGroundColor = Color.Lerp(currentGroundColor, nightGroundColor, elapsedTime / duration);
                Color _currentLightColor = Color.Lerp(currentLightColor, nightLightColor, elapsedTime / duration);
                float _currentLightIntensity = Mathf.Lerp(currentLightIntensity, nightLightIntensity, elapsedTime / duration);

                // Set the background color for all cameras
                foreach (Camera c in GetAllCams())
                {
                   // c.clearFlags = CameraClearFlags.SolidColor;
                  //  c.backgroundColor = _currentColor;
                    RenderSettings.skybox.SetColor("_SkyTint",_currentColor);
                    RenderSettings.skybox.SetColor("_GroundColor",_currentGroundColor);
                    RenderSettings.ambientIntensity = _currentLightIntensity;
                    cloudsMat.SetColor("_AlbedoColor", _currentCloudColor);
                    directionalLight.color = _currentLightColor;
                    currentColor = RenderSettings.skybox.GetColor("_SkyTint");
                    currentGroundColor = RenderSettings.skybox.GetColor("_GroundColor");
                    currentLightIntensity = RenderSettings.ambientIntensity;
                    currentLightColor = directionalLight.color;
                }

                // Increase the elapsed time
                elapsedTime += Time.deltaTime;

                // Wait for the next frame
                yield return null;
            }
        }

        // Ensure the final color is set
        foreach (Camera c in GetAllCams())
        {
            RenderSettings.skybox.SetColor("_SkyTint",currentColor);;
        }
    }

    void OnApplicationQuit()
    {
        RenderSettings.skybox.SetColor("_SkyTint", dayColor);
        RenderSettings.skybox.SetColor("_GroundColor", dayGroundColor);
        RenderSettings.ambientIntensity = dayLightIntensity;
        directionalLight.color = dayLightColor;
        cloudsMat = cloud.GetComponent<MeshRenderer>().sharedMaterial;
        cloudsMat.SetColor("_AlbedoColor", dayCloudColor);
    }
}
