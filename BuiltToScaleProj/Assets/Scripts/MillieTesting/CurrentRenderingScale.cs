using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRenderingScale : MonoBehaviour
{
    public Camera mirrorCam;

    public int smallScaleLayer;
    public int mediumScaleLayer;
    public int largeScaleLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScaleManager.Instance.isSmall)
        {
            EnableLayer(mirrorCam, smallScaleLayer);
            DisableLayer(mirrorCam, mediumScaleLayer);
            DisableLayer(mirrorCam, largeScaleLayer);
        }
        if (PlayerScaleManager.Instance.isMedium)
        {
            EnableLayer(mirrorCam, mediumScaleLayer);
            DisableLayer(mirrorCam, smallScaleLayer);
            DisableLayer(mirrorCam, largeScaleLayer);
        }
        if (PlayerScaleManager.Instance.isLarge)
        {
            EnableLayer(mirrorCam, largeScaleLayer);
            DisableLayer(mirrorCam, mediumScaleLayer);
            DisableLayer(mirrorCam, smallScaleLayer);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerScaleManager.Instance.playerScale = PlayerScaleManager.PlayerScale.Small;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerScaleManager.Instance.playerScale = PlayerScaleManager.PlayerScale.Medium;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerScaleManager.Instance.playerScale = PlayerScaleManager.PlayerScale.Large;
        }
        
    }
    
    void EnableLayer(Camera camera, int layer)
    {
        camera.cullingMask |= 1 << layer;
    }
    void DisableLayer(Camera camera, int layer)
    {
        camera.cullingMask &= ~(1 << layer);
    }
}
