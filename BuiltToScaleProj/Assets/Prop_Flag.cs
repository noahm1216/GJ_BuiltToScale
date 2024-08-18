using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Prop_Flag : InteractableProp
{
    public GameObject Flag;
    private LightModifier light;
    private float startPosY;
    public Transform endPoint;

    public UnityEvent ToggleGate;

    public override bool RequestInteraction(int ID)
    {
        if(ID == 2) //ID of mario flag
        {
            ToggleFlag();
            //Debug.Log("Flag pole interacted with");
        }
        
        return false;
    }

    private void Start()
    {
        light = InteractionManager.instance.GetComponent<LightModifier>();//Get reference to light modifier for isDay boolean
        startPosY = Flag.transform.position.y; //Get reference to end point for moving the object
    }
    private void Update()
    {
        //if (Flag.transform.localPosition.y < 0.65f)
        //{
        //    Flag.transform.localPosition += new Vector3(0, 0.005f, 0);
        //}
        //else
        //{
        //    Flag.transform.localPosition -= new Vector3(0, 1.233f, 0);
        //}
    }

    void ToggleFlag()
    {
        //Determine what flag should do based no time of day
        if(light.isDayTime)
        {
            //Try to raise the gate but the because the guard is not sleeping it will fail
            Debug.Log("It's day time. Gate failed.");
            return;
        }
        else
        {
            //Guard is sleeping, raise the gate to reveal the dragon
            ToggleGate?.Invoke();
            LowerFlag();

        }
    }

    void LowerFlag()
    {
        float end = endPoint.position.y;
        StartCoroutine(MoveFlag(startPosY, end, 1.0f));
    }

    private IEnumerator MoveFlag(float startY, float endY, float duration)
    {
        float elapsedTime = 0;

        // Capture the initial x and z positions of the gate object
        float startX = Flag.transform.position.x;
        float startZ = Flag.transform.position.z;

        while (elapsedTime < duration)
        {
            // Calculate the new y position
            float newY = Mathf.Lerp(startY, endY, elapsedTime / duration);

            // Set the gate object's position, only changing the y value
            Flag.transform.position = new Vector3(startX, newY, startZ);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object ends exactly at the end y position
        Flag.transform.position = new Vector3(startX, endY, startZ);
    }
}
