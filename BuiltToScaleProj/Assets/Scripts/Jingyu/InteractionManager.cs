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

    public LayerMask Layer;

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

    public bool RequestInteraction()
    {
        Ray ray = DimensionManager.instance.CurrentDimension.MainCamera.ScreenPointToRay(Input.mousePosition); // Create a ray from the mouse position
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, Layer);

        //Debug.Log(hits.Length);

        if (hits.Length > 0)
        {
            float closestDistance = float.MaxValue; // Variable to keep track of the closest hit
            Transform closestHit = null; // Transform of the closest object hit

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.GetComponent<InteractableProp>() != null && hit.distance < closestDistance) // Check if this hit is closer than the previous closest
                {
                    closestDistance = hit.distance;
                    closestHit = hit.transform;
                }
            }

            if (closestHit != null)
            {
                return (closestHit.GetComponent<InteractableProp>().RequestInteraction(ItemToDrag.ID));
            }
        }
        return false;
    }
}
