using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : InteractableProp
{
    public GameObject GameCompleteCutscene;
    public override bool RequestInteraction(int ID)
    {
        if (ID == 0)
        {
            GameCompleteCutscene.SetActive(true);
            //GameCompleteCutsceneRemote.Play();
            return true;
        }
        return false;
    }
}
