using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioGame : InteractableProp
{
    public GameObject Dragon;
    public GameObject DragonCollider;
    public override bool RequestInteraction(int ID)
    {
        if (ID == 0)
        {
            Dragon.SetActive(true);
            DragonCollider.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            return true;
        }
        return false;
    }
}
