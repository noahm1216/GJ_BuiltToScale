using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_MoonPlacer : InteractableProp
{


    public override bool RequestInteraction(int ID)
    {
        InteractableObject obj;
        InteractionManager.instance.interactableObjects.TryGetValue(ID, out obj);
        string name = obj._name;
        switch (ID)
        {
            case 1:
                Debug.Log(name + " Detected");
                obj.gameObject.SetActive(true);//Reactivate the obect
                obj.gameObject.transform.position = gameObject.transform.position; //Set the moon to the specified position.
                InteractionManager.instance.GetComponent<LightModifier>().FadeToColor(false,1.0f);
                break;

            default:
                Debug.Log("Moon not placed. No prop detected.");
                break;

               
        }
        return false;
    }

}
