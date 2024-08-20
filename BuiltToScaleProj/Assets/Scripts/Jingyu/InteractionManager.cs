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

    public Dictionary<int,InteractableObject> interactableObjects = new Dictionary<int,InteractableObject>();

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
    private void Start()
    {
        StoreObjects();

    }

    InteractableObject[] FindAllInteractableObjects()
    {
        return FindObjectsOfType<InteractableObject>();
    }

    void StoreObjects()//This is useful if need to reactivate objects in the scene. 
    {
        for (int i = 0; i < FindAllInteractableObjects().Length; i++)
        {
            int id = FindAllInteractableObjects()[i].ID;//Caches an interactable object ID
            InteractableObject obj = FindAllInteractableObjects()[i]; //Caches an interactable object
            interactableObjects.Add(id, obj);//Adds to dictionary 
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
                bool something = (closestHit.GetComponent<InteractableProp>().RequestInteraction(ItemToDrag.ID));
               
                if (something)
                {
                    PopUpFeedback.Instance.RequestMessage(Message.Interaction, closestHit.gameObject.name);
                }
                else
                {
                    //PopUpFeedback.Instance.RequestMessage(Message.FailedInteraction, closestHit.gameObject.name);
                }

                /*if(something && logInMessages.Instance)
                    logInMessages.Instance.SendMessage($"Item:{ItemToDrag.ID} INTERACTED WITH - {closestHit.transform.name}");
                else if(!something && logInMessages.Instance)
                    logInMessages.Instance.SendMessage($"Item:{ItemToDrag.ID} - {closestHit.transform.name}");*/

                return something;
            }
        }
        // no playable object
        if (logInMessages.Instance)
            logInMessages.Instance.SendMessage($"Item:{ItemToDrag.ID} - DOESNT INTERACT WITH THAT");
        return false;
    }
}
