using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public Sprite Image;


    private void OnMouseDown()
    {
        GameObject g = Instantiate(InteractionManager.instance.UIButtonPrefab, InteractionManager.instance.UIButtonHolder);
        g.GetComponentInChildren<Image>().sprite = Image;
        this.gameObject.SetActive(false);
    }
}
