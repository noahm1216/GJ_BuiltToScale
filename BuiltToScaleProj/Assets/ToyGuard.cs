using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyGuard : MonoBehaviour
{
    public Material NormalMat;
    public Material AngryMat;
    public LightModifier LightModifierRef;
    bool CanBeAngry = true;

    private void OnMouseDown()
    {
        BeAngry();
    }

    public void BeAngry()
    {
        if (CanBeAngry)
        {
            StartCoroutine(Angry());
        }
    }

    private void Update()
    {

    }

    public IEnumerator Angry()
    {
        if (GetComponent<MeshRenderer>().enabled)
        {
            CanBeAngry = false;
            GetComponent<MeshRenderer>().material = AngryMat;
            GetComponentInChildren<EnableRandomObjs>().PickRandomObj();
        }
        yield return new WaitForSeconds(1);
        if (GetComponent<MeshRenderer>().enabled)
        {
            CanBeAngry = true;
            GetComponent<MeshRenderer>().material = NormalMat;
            GetComponentInChildren<EnableRandomObjs>().DisableAllObjects();
        }
    }
}
