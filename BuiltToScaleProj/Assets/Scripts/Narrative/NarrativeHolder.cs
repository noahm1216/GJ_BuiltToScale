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


    public int nextSkyId;
    public List<NarrativeList> skyInfo = new List<NarrativeList>();
    [Space]
    public int nextMonsterFeedbackId;
    public List<NarrativeList> monsterFeedbackInfo = new List<NarrativeList>();
    [Space]
    public int nextToyFeedbackId;
    public List<NarrativeList> toyFeedbackInfo = new List<NarrativeList>();
    [Space]
    public int nextFlagPoleFeedbackId;
    public List<NarrativeList> flagPoleFeedbackInfo = new List<NarrativeList>();
    [Space]
    public int nextChestFeedbackId;
    public List<NarrativeList> flagChestFeedbackInfo = new List<NarrativeList>();
    [Space]
    public int nextBoomboxFeedbackId;
    public List<NarrativeList> flagBoomboxFeedbackInfo = new List<NarrativeList>();

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

    #region WORLD SKY FEEDBACK LINES
    public string PlaySkyLine(string _nameToPlay)
    {
        if (skyInfo.Count == 0)
        {
            Debug.Log($"No Reference to output our messages to: BUT\nMESSAGE TRYING TO PLAY: {_nameToPlay}");
            return null;
        }        

        int id = 0;
        if (string.IsNullOrEmpty(_nameToPlay))
            _nameToPlay = skyInfo[nextSkyId].name;


        foreach (NarrativeList textLine in skyInfo)
        {
            if (textLine.name == _nameToPlay)
            {
                nextSkyId = id + 1;
                if (nextSkyId > skyInfo.Count - 1)
                    nextSkyId = 0;                
                if (skyInfo[nextSkyId].playAfterPrevious)
                    PlaySkyLine(skyInfo[nextSkyId].name);
                return textLine.textLine;
            }
            id++;
        }
        DidntFindLine(_nameToPlay);
        return null;
    }
    #endregion player goal lines

    #region MONSTER FEEDBACK LINES
    public string PlayMonsterFeedBackLines(string _nameToPlay)
    {
        if (!logInMessages.Instance || monsterFeedbackInfo.Count == 0)
        {
            Debug.Log($"No Reference to output our messages to: BUT\nMESSAGE TRYING TO PLAY: {_nameToPlay}");
            return null;
        }
        

        int id = 0;
        if (string.IsNullOrEmpty(_nameToPlay))
            _nameToPlay = monsterFeedbackInfo[nextMonsterFeedbackId].name;

        foreach (NarrativeList textLine in monsterFeedbackInfo)
        {
            if (textLine.name == _nameToPlay)
            {
                nextMonsterFeedbackId = id + 1;
                if (nextMonsterFeedbackId > monsterFeedbackInfo.Count - 1)
                    nextMonsterFeedbackId = 0;

                logInMessages.Instance.SendMessage(textLine.textLine); // sends the voice line
                if (monsterFeedbackInfo[nextMonsterFeedbackId].playAfterPrevious)
                    PlayMonsterFeedBackLines(monsterFeedbackInfo[nextMonsterFeedbackId].name);
                return textLine.textLine;
            }
            id++;
        }
        DidntFindLine(_nameToPlay);
        return null;
    }
    #endregion monster feedback lines
    
    #region TOY FEEDBACK LINES
    public string PlayToyFeedBackLines(string _nameToPlay)
    {
        if (!logInMessages.Instance || toyFeedbackInfo.Count == 0)
        {
            Debug.Log($"No Reference to output our messages to: BUT\nMESSAGE TRYING TO PLAY: {_nameToPlay}");
            return null;
        }


        int id = 0;
        if (string.IsNullOrEmpty(_nameToPlay))
            _nameToPlay = toyFeedbackInfo[nextToyFeedbackId].name;

        foreach (NarrativeList textLine in toyFeedbackInfo)
        {
            if (textLine.name == _nameToPlay)
            {
                nextToyFeedbackId = id + 1;
                if (nextToyFeedbackId > toyFeedbackInfo.Count - 1)
                    nextToyFeedbackId = 0;

                logInMessages.Instance.SendMessage(textLine.textLine); // sends the voice line
                if (toyFeedbackInfo[nextToyFeedbackId].playAfterPrevious)
                    PlayMonsterFeedBackLines(toyFeedbackInfo[nextToyFeedbackId].name);
                return textLine.textLine;
            }
            id++;
        }
        DidntFindLine(_nameToPlay);
        return null;
    }
    #endregion toy feedback lines

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
    [Tooltip("If this box is checked it will playe after the previous line")]
    public bool playAfterPrevious;



    //public CustomerTypes(string _newName, float _newImpatienceLevel)
    //{

    //    name = _newName;
    //    impatienceLevel = _newImpatienceLevel;

    //}

}//end of NarrativeList dictionary

