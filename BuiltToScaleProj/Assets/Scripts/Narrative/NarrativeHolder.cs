using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeHolder : MonoBehaviour
{
    //----click
    //Sky
    //Monster
    //FlagPole
    //ToyGuard
    //Chest
    //Boombox

    //----Collect
    //Key
    //Flag
    //Monster Toy
    //Moon
    //RickRoll
    //DancingSquad

    //----Interact
    //Sky (with moon)
    //Monster (with dragon toy)
    //FlagPole (with toy flagpole)
    //Chest (with key)
    //Boombox (DancingSquad)

    public enum InteractType {Click, Collect, Interaction }
    public enum InteractionObject { Boombox, Chest, DancingSquad, Flag, FlagPole, Key, Moon, Monster, MonsterToy, ToyGuard, RickRoll, Sky,}

    [Space]
    [Header("LINES FOR FEEDBACK\n_______________")]
    public List<NarrativeList> interactionFeedbackList = new List<NarrativeList>();


    private void DidntFindLine(string _nameToPlay)
    {
        Debug.Log($"No Reference to output our messages to: BUT\nMESSAGE TRYING TO PLAY: {_nameToPlay}");
    }       


    public string PickRandomInteractionLine(NarrativeHolder.InteractionObject _objName, NarrativeHolder.InteractType _interactType)
    {
        if (interactionFeedbackList.Count == 0)
            return "Sorry, we forgot to setup the interaction lines";

        // then we make a temporary list of all the lines and pick a random one
        List<NarrativeList> linesWeCanChooseFrom = new List<NarrativeList>();

        foreach(NarrativeList feedbackLine in interactionFeedbackList)
        {
            if (feedbackLine.objInteractName == _objName && feedbackLine.interactionRequired == _interactType)
                linesWeCanChooseFrom.Add(feedbackLine);
        }

        if(linesWeCanChooseFrom.Count > 0)
        {
            int randomFeedbackId = Random.Range(0, linesWeCanChooseFrom.Count - 1);
            return linesWeCanChooseFrom[randomFeedbackId].textLine;
        }

        return $"Sorry, we must have not written a feedback for when we {_interactType} the {_objName}";
    }


}// end of NarrativeHolder class








// the custom list we'll use to manage different voice lines
[System.Serializable]
public class NarrativeList
{
    [Tooltip("Nickname of the narration type")]
    public string name;
    [Tooltip("Nickname of the narration object we will click")]
    public NarrativeHolder.InteractionObject objInteractName;
    [Tooltip("The Type of Interaction this line will play with")]
    public NarrativeHolder.InteractType interactionRequired;
    [Tooltip("This is the text that will display on screen")]
    public string textLine;
   



    //public CustomerTypes(string _newName, float _newImpatienceLevel)
    //{

    //    name = _newName;
    //    impatienceLevel = _newImpatienceLevel;

    //}

}//end of NarrativeList dictionary

