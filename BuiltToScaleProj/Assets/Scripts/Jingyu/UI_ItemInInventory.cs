using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemInInventory : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int ID;
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Optionally handle pointer down events
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        InteractionManager.instance.StartDragging(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool b = InteractionManager.instance.RequestInteraction();
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    }
}
