using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moon : InteractableObject
{
    public UnityEvent <bool,float> signalLight;
    // Start is called before the first frame update

    protected override void OnMouseDown()
    {
        signalLight?.Invoke(true,2.0f);
        base.OnMouseDown();
    }



}
