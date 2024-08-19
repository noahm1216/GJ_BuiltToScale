using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : InteractableProp
{
    public GameObject Monsters;

    public override bool RequestInteraction(int ID)
    {
        if (ID == 4)
        {
            Monsters.SetActive(true);
            return true;
        }
        return false;
    }

}
