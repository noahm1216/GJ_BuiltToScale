using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    public static DimensionManager instance;

    public Dimension CurrentDimension;

    [SerializeField]
    float ZoomInSequenceDuration = 1;

    bool CanTransition = true;

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

    void Start()
    {
        foreach (Camera c in FindObjectsOfType(typeof(Camera)))
        {
            //c.enabled = false;
        }
        CurrentDimension.MainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RequestZoomOut(CurrentDimension);
        }
    }

    public void RequestZoomIn(Dimension fromDimension, Dimension toDimension)
    {
        if (CanTransition)
        {
            StartCoroutine(ZoomIn(fromDimension, toDimension, ZoomInSequenceDuration));
        }
    }

    public void RequestZoomOut(Dimension fromDimension)
    {
        if (CanTransition && fromDimension.ZoomOutDimension != null)
        {
            StartCoroutine(ZoomOut(fromDimension, fromDimension.ZoomOutDimension, ZoomInSequenceDuration));
        }
    }

    IEnumerator ZoomIn(Dimension fromDimension, Dimension toDimension, float Duration)
    {
        CanTransition = false;
        Debug.Log("Zoom In");


        Vector3 OriginalPosition = fromDimension.MainCamera.transform.position;
        Vector3 TargetPosition = toDimension.TransitionCamera.transform.position;
        Quaternion OriginalRotation = fromDimension.MainCamera.transform.rotation;
        Quaternion TargetRotation = toDimension.TransitionCamera.transform.rotation;
        float OriginalFieldofView = fromDimension.MainCamera.fieldOfView;
        float TargetFieldofView = toDimension.TransitionCamera.fieldOfView;


        float elapsedTime = 0f;
        while (elapsedTime < Duration)
        {
            fromDimension.MainCamera.transform.position = Vector3.Lerp(OriginalPosition, TargetPosition, elapsedTime / Duration);
            fromDimension.MainCamera.transform.rotation = Quaternion.Lerp(OriginalRotation, TargetRotation, elapsedTime / Duration);
            fromDimension.MainCamera.fieldOfView = Mathf.Lerp(OriginalFieldofView, TargetFieldofView, elapsedTime / Duration);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        fromDimension.MainCamera.enabled = false;
        toDimension.MainCamera.enabled = true;
        fromDimension.MainCamera.transform.position = OriginalPosition;
        fromDimension.MainCamera.fieldOfView = OriginalFieldofView;
        fromDimension.MainCamera.transform.rotation = OriginalRotation;

        CurrentDimension = toDimension;

        CanTransition = true;
    }

    IEnumerator ZoomOut(Dimension fromDimension, Dimension toDimension, float Duration)
    {
        CanTransition = false;
        Debug.Log("Zoom Out");
        CurrentDimension = toDimension;


        Vector3 OriginalPosition = fromDimension.TransitionCamera.transform.position;
        Vector3 TargetPosition = toDimension.MainCamera.transform.position;
        Quaternion OriginalRotation = fromDimension.TransitionCamera.transform.rotation;
        Quaternion TargetRotation = toDimension.MainCamera.transform.rotation;
        float OriginalFieldofView = fromDimension.TransitionCamera.fieldOfView;
        float TargetFieldofView = toDimension.MainCamera.fieldOfView;

        fromDimension.MainCamera.enabled = false;
        toDimension.MainCamera.enabled = true;

        float elapsedTime = 0f;
        while (elapsedTime < Duration)
        {
            toDimension.MainCamera.transform.position = Vector3.Lerp(OriginalPosition, TargetPosition, elapsedTime / Duration);
            toDimension.MainCamera.transform.rotation = Quaternion.Lerp(OriginalRotation, TargetRotation, elapsedTime / Duration);
            toDimension.MainCamera.fieldOfView = Mathf.Lerp(OriginalFieldofView, TargetFieldofView, elapsedTime / Duration);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        CanTransition = true;
    }
}
