using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : InteractableProp
{
    public GameObject ChestDoor;
    public GameObject Portal;


    public override bool RequestInteraction(int ID)
    {
        if (ID == 3)
        {
            StartCoroutine(OpenChest());
            return true;
        }
        return false;
    }


    IEnumerator OpenChest()
    {
        Portal.SetActive(true);
        Portal.GetComponent<GraphicRaycaster>().enabled = true;
        float TmpTime = 0;
        while (TmpTime < 2) {

            ChestDoor.transform.localEulerAngles = new Vector3(Mathf.Lerp(-90, 0, TmpTime / 2), -90, 90);
            TmpTime += Time.deltaTime;
            yield return null;
        }
    }
}
