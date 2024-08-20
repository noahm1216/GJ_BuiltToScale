using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionPortal : MonoBehaviour
{
    public Dimension PointsToDimension;

    public void ZoomInToDimension()
    {
        Debug.Log("Clicked On UI");
        DimensionManager.instance.RequestZoomIn(DimensionManager.instance.CurrentDimension, PointsToDimension);
    }

    private void OnMouseEnter()
    {
        CursorManager.instance.SwitchCursor(1);
    }

    private void OnMouseExit()
    {
        CursorManager.instance.SwitchCursor(0);
    }

}
