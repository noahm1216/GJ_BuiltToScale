using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
public class InteractableObject : MonoBehaviour
{
    public string _name;
    public Sprite Image;
    public int ID;

    protected virtual void OnMouseDown()
    {
        
        GameObject g = Instantiate(InteractionManager.instance.UIButtonPrefab, InteractionManager.instance.UIButtonHolder);
        g.GetComponentInChildren<Image>().sprite = Image;
        g.GetComponentInChildren<UI_ItemInInventory>().ID = ID;
        gameObject.SetActive(false);

        if (logInMessages.Instance)
            logInMessages.Instance.SendMessage($"You've Just Picked Up {_name}. You find yourself wondering what it's meant to combine with.");
    }
}
