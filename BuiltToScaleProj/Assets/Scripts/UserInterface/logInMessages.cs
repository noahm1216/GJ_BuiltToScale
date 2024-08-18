using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class logInMessages : MonoBehaviour
{
    public static logInMessages Instance{get; private set; }

    public TextMeshProUGUI message;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;       
    }

    private void Start()
    {
        message.text += "";
    }

    public void SendMessage(string _sentMessage)
    {
        if (message != null)
            message.text += $"\n\n{_sentMessage}";
        else
            Debug.Log($"Missing Text Bod To Send Message: {_sentMessage}");
    }
    
}
