using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableProp : MonoBehaviour
{
    
    public virtual bool RequestInteraction(int ID)
    {
        return false;
    }

    private void OnMouseEnter()
    {
        CursorManager.instance.SwitchCursor(1);
    }

    private void OnMouseExit()
    {
        CursorManager.instance.SwitchCursor(0);
    }

}
