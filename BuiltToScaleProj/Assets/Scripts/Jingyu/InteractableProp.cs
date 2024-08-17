using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableProp : MonoBehaviour
{
    public virtual bool RequestInteraction(int ID)
    {
        return false;
    }
}
