using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance;

    public bool IsDragging;
    public UI_ItemInInventory ItemToDrag;

    public Transform UIButtonHolder;
    public GameObject UIButtonPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (IsDragging && ItemToDrag != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(ItemToDrag.GetComponent<RectTransform>(), Input.mousePosition, DimensionManager.instance.CurrentDimension.MainCamera, out Vector2 localPoint);
        ItemToDrag.ItemUI.GetComponent<RectTransform>().localPosition = localPoint;
        }*/
    }

    public void StartDragging(UI_ItemInInventory Item)
    {
        //Need to clear previous items

        ItemToDrag = Item;
        
        IsDragging = true;
    }
}
