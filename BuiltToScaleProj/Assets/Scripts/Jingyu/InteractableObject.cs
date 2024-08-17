using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public Sprite Image;
    public int ID;


    private void OnMouseDown()
    {
        GameObject g = Instantiate(InteractionManager.instance.UIButtonPrefab, InteractionManager.instance.UIButtonHolder);
        g.GetComponentInChildren<Image>().sprite = Image;
        g.GetComponentInChildren<UI_ItemInInventory>().ID = ID;
        gameObject.SetActive(false);
    }
}
