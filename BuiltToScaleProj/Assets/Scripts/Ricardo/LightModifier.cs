using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightModifier : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;

    private Color currentColor;

    public GameObject Moon;
    public Vector3 MoonDownPosition;
    public Vector3 MoonUpPosition;




    // Start is called before the first frame update
    void Start()
    {
        
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
        }


    }

    public void SetNight()
    {
        //Iterate through each camera in the scene and turn background to solid color
        foreach (Camera c in GetAllCams())
        {
            c.clearFlags = CameraClearFlags.SolidColor;
            c.backgroundColor = nightColor;
            currentColor = c.backgroundColor;
        }
    }

    public void SetDay()
    {
        //Iterate through each camera in the scene and turn background to solid color
        foreach (Camera c in GetAllCams())
        {
            c.clearFlags = CameraClearFlags.SolidColor;
            c.backgroundColor = dayColor;
            currentColor = c.backgroundColor;
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
            currentColor = c.backgroundColor;
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

                // Set the background color for all cameras
                foreach (Camera c in GetAllCams())
                {
                    currentColor = c.backgroundColor;
                    c.clearFlags = CameraClearFlags.SolidColor;
                    c.backgroundColor = _currentColor;
                    currentColor = c.backgroundColor;
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



                // Calculate the current color based on the elapsed time
                Color _currentColor = Color.Lerp(currentColor, nightColor, elapsedTime / duration);

                // Set the background color for all cameras
                foreach (Camera c in GetAllCams())
                {
                    c.clearFlags = CameraClearFlags.SolidColor;
                    c.backgroundColor = _currentColor;
                    currentColor = c.backgroundColor;
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
            c.backgroundColor = currentColor;
        }
    }
}
