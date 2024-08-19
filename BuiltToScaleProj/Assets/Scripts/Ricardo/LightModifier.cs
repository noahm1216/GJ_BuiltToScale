using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightModifier : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;
    
    public Color dayCloudColor;
    public Color nightCloudColor;

    private Color currentColor;
    private Color currentCloudColor;
    public bool isDayTime = true;

    public GameObject Moon;
    public Vector3 MoonDownPosition;
    public Vector3 MoonUpPosition;

    public List<GameObject> clouds;
    public Material cloudsMat;
    public GameObject cloud;




    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetColor("_SkyTint", dayColor);
        cloudsMat = cloud.GetComponent<MeshRenderer>().sharedMaterial;
        cloudsMat.SetColor("_BaseColor", dayCloudColor);
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
            currentCloudColor = cloudsMat.GetColor("_BaseColor");
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
            cloudsMat.SetColor("_BaseColor", nightCloudColor);
            currentColor = RenderSettings.skybox.GetColor("_SkyTint");
            currentCloudColor = cloudsMat.GetColor("_BaseColor");
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
            cloudsMat.SetColor("_BaseColor", dayCloudColor);
            currentColor = RenderSettings.skybox.GetColor("_SkyTint");
            currentCloudColor = cloudsMat.GetColor("_BaseColor");
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
            currentCloudColor = cloudsMat.GetColor("_BaseColor");
        }
    }

    public void FadeToColor(bool day = true, float duration = 0)
    {
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
                isDayTime = true;
                // Set the background color for all cameras
                foreach (Camera c in GetAllCams())
                {
                  //  currentColor = c.backgroundColor;
                    currentColor = RenderSettings.skybox.GetColor("_SkyTint");
                    currentCloudColor = cloudsMat.GetColor("_BaseColor");
                   // c.clearFlags = CameraClearFlags.SolidColor;
                   // c.backgroundColor = _currentColor;
                   RenderSettings.skybox.SetColor("_SkyTint", _currentColor);
                   cloudsMat.SetColor("_BaseColor", _currentCloudColor);
                    currentColor = RenderSettings.skybox.GetColor("_SkyTint");
                    currentCloudColor = cloudsMat.GetColor("_BaseColor");
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

                // Set the background color for all cameras
                foreach (Camera c in GetAllCams())
                {
                   // c.clearFlags = CameraClearFlags.SolidColor;
                  //  c.backgroundColor = _currentColor;
                    RenderSettings.skybox.SetColor("_SkyTint",_currentColor);
                    cloudsMat.SetColor("_BaseColor", _currentCloudColor);
                    currentColor = RenderSettings.skybox.GetColor("_SkyTint");
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
}
