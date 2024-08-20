using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class logInMessages : MonoBehaviour
{
    public static logInMessages Instance{get; private set; }

    public TextMeshProUGUI message;

    public bool drawerOpen = true;
    public RectTransform logTransform;

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

    public void CloseDrawer()
    {
        if (drawerOpen)
        {
           // logTransform.position = new Vector3(logTransform.localPosition.x-150, logTransform.localPosition.y, logTransform.localPosition.z);
           logTransform.anchoredPosition = new Vector2(logTransform.anchoredPosition.x - 300, logTransform.anchoredPosition.y);
            drawerOpen = false;
        }
        else if (!drawerOpen)
        {
            //  logTransform.localPosition = new Vector3(logTransform.localPosition.x + 150, logTransform.localPosition.y, logTransform.localPosition.z);
            logTransform.anchoredPosition = new Vector2(logTransform.anchoredPosition.x + 300, logTransform.anchoredPosition.y);
            drawerOpen = true;
        }
    }
    public void OpenDrawer()
    {
        if (!drawerOpen)
        {
          //  logTransform.localPosition = new Vector3(logTransform.localPosition.x + 150, logTransform.localPosition.y, logTransform.localPosition.z);
          logTransform.anchoredPosition = new Vector2(logTransform.anchoredPosition.x + 300, logTransform.anchoredPosition.y);
          drawerOpen = true;
        }
    }
    
}
