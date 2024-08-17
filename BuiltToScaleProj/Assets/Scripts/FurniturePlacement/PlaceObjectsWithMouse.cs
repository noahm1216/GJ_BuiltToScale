using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceObjectsWithMouse : MonoBehaviour
{
    // assets we will call on
    public Transform[] libraryOfAssets;
    public Sprite[] libraryOfAssetImages;
    // assets we will load
    private Transform[] poolCopyOfSpawnedObjects;
    public Image[] ui_NextIcons;
    private int[] selectionId = new int[3];

    private Transform mouseHolderObject;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mouseHolderObject = new GameObject("MouseHolderObj").transform;

        if (ErrorChecker())
            return;

        PrepareModels();
        GenerateNextIds(0);
    }

    public bool ErrorChecker()
    {
        if (libraryOfAssets.Length == 0) { Debug.Log("Missing Asset Objs"); return true; }
        if (libraryOfAssetImages.Length == 0) { Debug.Log("Missing Asset Imgs"); return true; }
        if (!mainCamera) { Debug.Log("Missing Main Camera"); return true; }
        if (!mouseHolderObject) { Debug.Log("Missing Mouse Holder Object"); return true; }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ErrorChecker())
            return;
        AlignPositionToMouse();
    }

    // spawn copies of the model and prepare to show them
    public void PrepareModels()
    {
        poolCopyOfSpawnedObjects = new Transform[libraryOfAssetImages.Length];

        for (int i = 0; i < libraryOfAssets.Length; i++)
        {
            Transform cloneModel = Instantiate(libraryOfAssets[i]);
            poolCopyOfSpawnedObjects[i] = cloneModel;
            cloneModel.transform.localScale = new Vector3(.1f, .1f, .1f);
            cloneModel.SetParent(mouseHolderObject);
            cloneModel.localPosition = Vector3.zero;
        }
    }

    public void GenerateNextIds(int _amountToGen)
    {
        for (int i = _amountToGen; i < selectionId.Length; i++)
        {
            selectionId[i] = Random.Range(0, libraryOfAssets.Length - 1);
        }
        UpdateUI();
    }

    // grab an image for each of the models we'll show
    public void UpdateUI()
    {
        for (int i = 0; i < selectionId.Length; i++)
        {
            foreach (Sprite imgIcon in libraryOfAssetImages)
            {
                if (imgIcon.name.Contains(libraryOfAssets[selectionId[i]].name))
                {
                    ui_NextIcons[i].sprite = imgIcon;
                    break;
                }
            }
        }
    }

    public void ShiftUpModels()
    {

    }

    public void AlignPositionToMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(transform.position, hit.point);
            mouseHolderObject.transform.position = hit.point;
        }
    }
}
