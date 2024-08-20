using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    public Texture2D[] CursorList;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        /*Ray ray = DimensionManager.instance.CurrentDimension.MainCamera.ScreenPointToRay(Input.mousePosition); // Create a ray from the mouse position
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, LayerInfo);

        if (hits.Length > 0)
        {
            if (hits[0].transform.GetComponent<InteractableObject>() != null)
            {
                Cursor.SetCursor(InteractiveObjejctCursor, Vector2.zero, CursorMode.Auto);
            }
            else if (hits[0].transform.GetComponent<InteractableProp>() != null)
            {
                Cursor.SetCursor(InteractiveObjejctCursor, Vector2.zero, CursorMode.Auto);
            }
            else if (hits[0].transform.GetComponent<DimensionPortal>() != null)
            {
                Cursor.SetCursor(InteractiveObjejctCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
            }
        }*/
    }

    public void SwitchCursor(int cursorIndex)
    {
        Cursor.SetCursor(CursorList[cursorIndex], Vector2.zero, CursorMode.Auto);
    }
}
