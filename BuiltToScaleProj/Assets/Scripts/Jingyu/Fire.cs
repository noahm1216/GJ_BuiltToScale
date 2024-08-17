using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : InteractableProp
{
    public override bool RequestInteraction(int ID)
    {
        if (ID == 0)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
