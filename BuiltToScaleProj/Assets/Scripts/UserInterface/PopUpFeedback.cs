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
        }
        else if (messageType == Message.Collect)
        {
            //Key
            //Flag
            //Monster Toy
            //Moon
            //RickRoll
            //DancingSquad
        }
        else if (messageType == Message.Interaction)
        {
            //Sky
            //Monster
            //FlagPole
            //ToyGuard
            //Chest
            //Boombox
        }

        if (feedbackTextBox)
            feedbackTextBox.text = StringToDisplay;

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
