using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Message{
    Click,
    Collect,
    Interaction
}



public class PopUpFeedback : MonoBehaviour
{
    public static PopUpFeedback Instance;
    public TextMeshProUGUI feedbackTextBox;
    public Image feedbackBackgroundImage;
    public NarrativeHolder ref_NarrativeHolder;
    private Color textStartColor, imageStartColor;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        if (feedbackTextBox)
            textStartColor = feedbackTextBox.color;
        if (feedbackBackgroundImage)
            imageStartColor = feedbackBackgroundImage.color;        
    }

    public void RequestMessage(Message messageType, string name) // Call this and assign the text. it will handle the rest
    {
        string StringToDisplay = "Hi Hi! from" + name;
        if (messageType == Message.Click)
        {
            //Sky
            //Monster
            //FlagPole
            //ToyGuard
            //Chest
            //Boombox
            switch (name)
            {
                case "Sky":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Sky, NarrativeHolder.InteractType.Click);
                    break;
                case "Monster":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Monster, NarrativeHolder.InteractType.Click);
                    break;
                case "FlagPole":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.FlagPole, NarrativeHolder.InteractType.Click);
                    break;
                case "ToyGuard":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.ToyGuard, NarrativeHolder.InteractType.Click);
                    break;
                case "Chest":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Chest, NarrativeHolder.InteractType.Click);
                    break;
                case "Boombox":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Boombox, NarrativeHolder.InteractType.Click);
                    break;
                default:
                    break;
            }
        }
        else if (messageType == Message.Collect)
        {
            //Key
            //Flag
            //Monster Toy
            //Moon
            //RickRoll
            //DancingSquad
            switch (name)
            {
                case "Key":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Key, NarrativeHolder.InteractType.Collect);
                    break;
                case "Flag":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Flag, NarrativeHolder.InteractType.Collect);
                    break;
                case "Monster Toy":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.MonsterToy, NarrativeHolder.InteractType.Collect);
                    break;
                case "Moon":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Moon, NarrativeHolder.InteractType.Collect);
                    break;
                case "RickRoll":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.RickRoll, NarrativeHolder.InteractType.Collect);
                    break;
                case "DancingSquad":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.DancingSquad, NarrativeHolder.InteractType.Collect);
                    break;
                default:
                    break;
            }
        }
        else if (messageType == Message.Interaction)
        {
            //Sky (with moon)
            //Monster (with dragon toy)
            //FlagPole (with toy flagpole)
            //Chest (with key)
            //Boombox (DancingSquad)
            switch (name)
            {
                case "Sky":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Sky, NarrativeHolder.InteractType.Interaction);
                    break;
                case "Monster":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Monster, NarrativeHolder.InteractType.Interaction);
                    break;
                case "FlagPole":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.FlagPole, NarrativeHolder.InteractType.Interaction);
                    break;
                case "Chest":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Chest, NarrativeHolder.InteractType.Interaction);
                    break;
                case "Boombox":
                    StringToDisplay = ref_NarrativeHolder.PickRandomInteractionLine(NarrativeHolder.InteractionObject.Boombox, NarrativeHolder.InteractType.Interaction);
                    break;
                default:
                    break;
            }
        }

        if (feedbackTextBox)
            feedbackTextBox.text = StringToDisplay;

        if (logInMessages.Instance)
            logInMessages.Instance.SendMessage(StringToDisplay); // sends the log to chat history

        EnableUI();
    }

    public void EnableUI()
    {
        if (feedbackTextBox)
            feedbackTextBox.color = textStartColor;
        if (feedbackBackgroundImage)
            feedbackBackgroundImage.color = imageStartColor;

        feedbackBackgroundImage.GetComponent<RectTransform>().anchoredPosition = (Input.mousePosition + new Vector3(Random.Range(-50,50), Random.Range(-50, 50))) / GetComponent<Canvas>().scaleFactor;
        StopAllCoroutines();
        StartCoroutine(FadeUI());
    }

    public IEnumerator FadeUI()
    {
        yield return new WaitForSeconds(1);
        Vector2 OriginalPos = feedbackTextBox.GetComponent<RectTransform>().anchoredPosition;
        for (float i = 1; i >= 0; i-=0.1f)
        {
            //print($"UI ALPHA: {i}");
            if (feedbackTextBox)
            {
                feedbackTextBox.color = new Color(feedbackTextBox.color.r, feedbackTextBox.color.g, feedbackTextBox.color.b, i);
                feedbackTextBox.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 10);
            }

            if (feedbackBackgroundImage)
                feedbackBackgroundImage.color = new Color(feedbackBackgroundImage.color.r, feedbackBackgroundImage.color.g, feedbackBackgroundImage.color.b, i);



            yield return new WaitForSeconds(0.05f);
        }

        if (feedbackTextBox)
        {
            feedbackTextBox.color = new Color(feedbackTextBox.color.r, feedbackTextBox.color.g, feedbackTextBox.color.b, 0);
            feedbackTextBox.GetComponent<RectTransform>().anchoredPosition = OriginalPos;
        }

        if (feedbackBackgroundImage)
            feedbackBackgroundImage.color = new Color(feedbackBackgroundImage.color.r, feedbackBackgroundImage.color.g, feedbackBackgroundImage.color.b, 0);



    }
    
}
