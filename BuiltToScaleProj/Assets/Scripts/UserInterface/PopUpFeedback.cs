using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpFeedback : MonoBehaviour
{
    public TextMeshProUGUI feedbackTextBox;
    public Image feedbackBackgroundImage;
    public NarrativeHolder ref_NarrativeHolder;
    private Color textStartColor, imageStartColor;

    // Start is called before the first frame update
    void Start()
    {
        if (feedbackTextBox)
            textStartColor = feedbackTextBox.color;
        if (feedbackBackgroundImage)
            imageStartColor = feedbackBackgroundImage.color;        
    }

    public void AssignText(string _newText) // Call this and assign the text. it will handle the rest
    {
        if(feedbackTextBox)
            feedbackTextBox.text = _newText;

        EnableUI();
    }

    public void EnableUI()
    {
        if (feedbackTextBox)
            feedbackTextBox.color = textStartColor;
        if (feedbackBackgroundImage)
            feedbackBackgroundImage.color = imageStartColor;

        StartCoroutine(FadeUI());
    }

    public IEnumerator FadeUI()
    {
        yield return new WaitForSeconds(8.5f);

        for (float i = 1; i >= 0; i-=0.1f)
        {
            print($"UI ALPHA: {i}");
            if (feedbackTextBox)
                feedbackTextBox.color =  new Color(feedbackTextBox.color.r, feedbackTextBox.color.g, feedbackTextBox.color.b, i);

            if (feedbackBackgroundImage)
                feedbackBackgroundImage.color = new Color(feedbackBackgroundImage.color.r, feedbackBackgroundImage.color.g, feedbackBackgroundImage.color.b, i);

            yield return new WaitForSeconds(0.05f);
        }

        if (feedbackTextBox)
            feedbackTextBox.color = new Color(feedbackTextBox.color.r, feedbackTextBox.color.g, feedbackTextBox.color.b, 0);

        if (feedbackBackgroundImage)
            feedbackBackgroundImage.color = new Color(feedbackBackgroundImage.color.r, feedbackBackgroundImage.color.g, feedbackBackgroundImage.color.b, 0);

    }
    
}
