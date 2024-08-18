using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float moveSpeed = 5;
    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.fixedDeltaTime;
        if (transform.position.x > (pos.x + 15))
            transform.position = pos;
    }
}
