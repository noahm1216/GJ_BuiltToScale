using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Flag : MonoBehaviour
{
    public GameObject Flag;
    private void Update()
    {
        if (Flag.transform.localPosition.y < 0.65f)
        {
            Flag.transform.localPosition += new Vector3(0, 0.005f, 0);
        }
        else
        {
            Flag.transform.localPosition -= new Vector3(0, 1.233f, 0);
        }
    }
}
