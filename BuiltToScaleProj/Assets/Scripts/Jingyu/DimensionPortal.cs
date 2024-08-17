using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionPortal : MonoBehaviour
{
    public Dimension PointsToDimension;

    public void ZoomInToDimension()
    {
        DimensionManager.instance.RequestZoomIn(DimensionManager.instance.CurrentDimension, PointsToDimension);
    }

}
