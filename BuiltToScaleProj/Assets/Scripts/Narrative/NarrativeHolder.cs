using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeHolder : MonoBehaviour
{
    
    [Space]
    [Header("LINES FOR GOALS\n_______________")]
    public int nextGoalId;
    public List<NarrativeList> gameGoalInfo = new List<NarrativeList>();

    [Space]
    [Header("LINES FOR FEEDBACK\n_______________")]
    public int nextMonsterFeedbackId;
    public List<NarrativeList> monsterFeedbackInfo = new List<NarrativeList>();
    [Space]
    public int nextToyFeedbackId;
    public List<NarrativeList> toyFeedbackInfo = new List<NarrativeList>();

    private void DidntFindLine(string _nameToPlay)
    {
        Debug.Log($"No Reference to output our messages to: BUT\nMESSAGE TRYING TO PLAY: {_nameToPlay}");
    }

    #region PLAYER GOAL LINES
    public string PlayGoalLine(string _nameToPlay)
    {
        if (!logInMessages.Instance || gameGoalInfo.Count == 0)
        {
            Debug.Log($"No Reference to output our messages to: BUT\nMESSAGE TRYING TO PLAY: {_nameToPlay}");
            return null;
        }        

        int id = 0;
        if (string.IsNullOrEmpty(_nameToPlay))
            _nameToPlay = gameGoalInfo[nextGoalId].name;


        foreach (NarrativeList textLine in gameGoalInfo)
        {
            if (textLine.name == _nameToPlay)
            {
                nextGoalId = id + 1;
                if (nextGoalId > gameGoalInfo.Count - 1)
                    nextGoalId = 0;
                logInMessages.Instance.SendMessage(textLine.textLine); // sends the voice line
                if (gameGoalInfo[nextGoalId].playAfterPrevious)
                    PlayGoalLine(gameGoalInfo[nextGoalId].name);
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

