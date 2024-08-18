using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moon : InteractableObject
{
    public UnityEvent  ObjectSelected;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    protected override void OnMouseDown()
    {
        ObjectSelected?.Invoke();
        InteractionManager.instance.GetComponent<LightModifier>().FadeToColor(true,1.0f);
        base.OnMouseDown();
    }



}
