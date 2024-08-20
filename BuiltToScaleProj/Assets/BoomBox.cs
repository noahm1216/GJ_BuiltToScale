using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Video;

public class BoomBox : InteractableProp
{
    public GameObject Monsters;
    public GameObject BurntBoomBox;
    public GameObject GameCompleteCutscene;
    public PlayableDirector GameCompleteCutsceneRemote;

    public Dimension Ending_World10;

    public AudioSource World1Audio;
    public AudioClip RickRollMusic;

    public Animator monsterAnimator;

    public PlayableDirector endCinematic;

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
            monsterAnimator.SetTrigger("RickRoll_MX_on");
        }

        if (ID == 0)
        {
            
           StartCoroutine(ActivateEndCutscene());
            
            //GameCompleteCutsceneRemote.Play();
            return true;
        }
        return false;
    }


    IEnumerator ActivateEndCutscene()
    {
        PlayableAsset playableAsset = endCinematic.playableAsset;
        double duration = playableAsset.duration;
        float dur = (float)duration;
        GameCompleteCutscene.SetActive(true);
        yield return new WaitForSeconds(dur-1);
        //DimensionManager.instance.RequestZoomOut(DimensionManager.instance.CurrentDimension);

        Debug.Log("Played!");


        DimensionManager.instance.CurrentDimension.MainCamera.enabled = false;
        DimensionManager.instance.CurrentDimension.MainCamera.GetComponent<AudioListener>().enabled = false;
        foreach (GraphicRaycaster G in DimensionManager.instance.CurrentDimension.GetComponentsInChildren<GraphicRaycaster>())
        {
            G.enabled = false;
        }
        DimensionManager.instance.CurrentDimension.ZoomOutDimension = Ending_World10;
        DimensionManager.instance.CurrentDimension = Ending_World10;

        DimensionManager.instance.CurrentDimension.MainCamera.enabled = true;
        DimensionManager.instance.CurrentDimension.MainCamera.GetComponent<AudioListener>().enabled = true;
        foreach (GraphicRaycaster G in DimensionManager.instance.CurrentDimension.GetComponentsInChildren<GraphicRaycaster>())
        {
            G.enabled = true;
        }
        BurntBoomBox.SetActive(true);
    }
}
