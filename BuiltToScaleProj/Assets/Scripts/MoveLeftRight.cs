using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float moveSpeed = 5;
    Vector3 pos;
    public float secondUntilRestart;
    public bool randomizeRestartTime;
    float storedRestartTime;
    public Vector2 minMaxRandom;

    private void Start()
    {
        pos = transform.position;
        storedRestartTime = secondUntilRestart;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.fixedDeltaTime;
        if (transform.position.x > (pos.x + secondUntilRestart))
        {
            transform.position = pos;
            if (randomizeRestartTime)
            {
                secondUntilRestart = storedRestartTime + Random.Range(minMaxRandom.x, minMaxRandom.y);
            }
        }
    }
}
