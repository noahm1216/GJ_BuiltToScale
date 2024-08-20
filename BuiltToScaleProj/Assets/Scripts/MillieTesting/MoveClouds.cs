using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    public float firstTargetX;           // The x-coordinate of the first target position
    public float secondTargetX;          // The x-coordinate of the second target position
    public float minMoveSpeed = 0.5f;    // Minimum speed at which a child can move
    public float maxMoveSpeed = 2.0f;    // Maximum speed at which a child can move

    private Transform[] children;        // Store child transforms
    private Vector3[] initialPositions;  // Store initial positions to maintain y and z
    private float[] moveSpeeds;          // Store the random move speed for each child

    void Start()
    {
        // Get all child transforms
        int childCount = transform.childCount;
        children = new Transform[childCount];
        initialPositions = new Vector3[childCount];
        moveSpeeds = new float[childCount];

        for (int i = 0; i < childCount; i++)
        {
            children[i] = transform.GetChild(i);
            initialPositions[i] = children[i].position; // Store the initial positions
            moveSpeeds[i] = Random.Range(minMoveSpeed, maxMoveSpeed); // Assign a random speed to each child
        }
    }

    void Update()
    {
        // Move each child towards its target x-position while maintaining y and z
        for (int i = 0; i < children.Length; i++)
        {
            Vector3 newPosition = children[i].position;
            newPosition.x = Mathf.MoveTowards(newPosition.x, firstTargetX, moveSpeeds[i] * Time.deltaTime);
            children[i].position = newPosition;

            // If the child has reached the first target x-position
            if (Mathf.Abs(children[i].position.x - firstTargetX) < 0.01f)
            {
                // Immediately move the child to the second target x-position
                newPosition.x = secondTargetX;
                children[i].position = newPosition;

                // Assign a new random speed for the next movement
                moveSpeeds[i] = Random.Range(minMoveSpeed, maxMoveSpeed);
            }
            else if (Mathf.Abs(children[i].position.x - secondTargetX) < 0.01f)
            {
                // Move the child back towards the first target x-position
                newPosition.x = Mathf.MoveTowards(newPosition.x, firstTargetX, moveSpeeds[i] * Time.deltaTime);
                children[i].position = newPosition;
            }
        }
    }
}
