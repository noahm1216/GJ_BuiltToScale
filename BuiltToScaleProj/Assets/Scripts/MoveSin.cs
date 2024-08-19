using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    Vector3 pos;
    public float sinSpeed = 100;

    private void Start()
    {
        pos = transform.position;
    }

    private void FixedUpdate()
    {

        float sin = Mathf.Sin(pos.x);
        // transform.position = pos + new Vector3(pos.x, pos.y + sin, transform.position.z);
        transform.position += new Vector3(0, Mathf.Sin(Time.time * sinSpeed) / 50, 0);

    }
    

}
