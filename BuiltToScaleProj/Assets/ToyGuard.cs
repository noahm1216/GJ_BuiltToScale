using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyGuard : MonoBehaviour
{
    public Material NormalMat;
    public Material AngryMat;
    public LightModifier LightModifierRef;

    private void OnMouseDown()
    {
        StartCoroutine(Angry());
    }

    private void Update()
    {
        if (!LightModifierRef.isDayTime)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public IEnumerator Angry()
    {
        if (GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().material = AngryMat;
        }
        yield return new WaitForSeconds(1);
        if (GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().material = NormalMat;
        }
    }
}
