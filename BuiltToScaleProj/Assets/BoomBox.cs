using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BoomBox : InteractableProp
{
    public GameObject Monsters;
    public GameObject GameCompleteCutscene;
    public PlayableDirector GameCompleteCutsceneRemote;

    public AudioSource World1Audio;
    public AudioClip RickRollMusic;

    public override bool RequestInteraction(int ID)
    {
        if (ID == 4)
        {
            Monsters.SetActive(true);
            return true;
        }

        if (ID == 5)
        {
            World1Audio.clip = RickRollMusic;
            World1Audio.Play();
        }

        if (ID == 0)
        {
            GameCompleteCutscene.SetActive(true);
            //GameCompleteCutsceneRemote.Play();
            return true;
        }
        return false;
    }

}
