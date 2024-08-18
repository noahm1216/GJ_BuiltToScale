using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    public Transform openPos;
    public GameObject gateObject;
    public float moveSpeed = 1.0f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gateObject.transform.position; //Cache starting position
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DetermineState()
    {
        //Debug.Log("Determining State...");
        Vector3 pos = gateObject.transform.position;
        if(pos.y == startPos.y)
        {
            isOpen = false;
            //Debug.Log("Is CLOSED");
        }
        else if(pos.y == openPos.position.y)
        {
            isOpen = true;
            //Debug.Log("Is OPEN");
        }
    }

    void DetermineMovement()
    {
        //Debug.Log("Moving...");
        if (isOpen)
        {
            Vector3 pos = openPos.position;
            StartCoroutine(MoveObject(pos.y, startPos.y, moveSpeed));
        }
        else
        {
            Vector3 pos = openPos.position;
            StartCoroutine(MoveObject(startPos.y, pos.y, moveSpeed));
        }
    }

    IEnumerator MoveObject(float startY, float endY, float duration)
    {
        float elapsedTime = 0;

        // Capture the initial x and z positions of the gate object
        float startX = gateObject.transform.position.x;
        float startZ = gateObject.transform.position.z;

        while (elapsedTime < duration)
        {
            // Calculate the new y position
            float newY = Mathf.Lerp(startY, endY, elapsedTime / duration);

            // Set the gate object's position, only changing the y value
            gateObject.transform.position = new Vector3(startX, newY, startZ);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object ends exactly at the end y position
        gateObject.transform.position = new Vector3(startX, endY, startZ);
    }

    public void MoveDoor()
    {
        DetermineState();   
        DetermineMovement();
        //Debug.Log("Movement finished..");
    }
    
}
