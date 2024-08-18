using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float moveSpeed = 5;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x += moveSpeed * Time.fixedDeltaTime;
        if (pos.x > 20)
            pos.x = -15;
        transform.position = pos;
    }
}
