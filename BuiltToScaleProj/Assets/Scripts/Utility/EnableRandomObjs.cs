using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRandomObjs : MonoBehaviour
{
    public int nextIdToEnable = 0;
    public GameObject[] objsToEnable;

    // Start is called before the first frame update
    void Start()
    {
        if (objsToEnable.Length == 0)
            return;

        foreach (GameObject obj in objsToEnable)
            obj.SetActive(false);
    }

    public void PickRandomObj()
    {
        if (objsToEnable.Length == 0)
            return;

        foreach (GameObject obj in objsToEnable)
            obj.SetActive(false);

        if (nextIdToEnable < objsToEnable.Length)
            objsToEnable[nextIdToEnable].SetActive(true);

        ChangeNumberRandomly();
    }

    public void ChangeNumberRandomly()
    {
        if (objsToEnable.Length == 0)
            return;

        nextIdToEnable = Random.Range(0, objsToEnable.Length);
    }

    public void PickObjById(int _id)
    {
        if (objsToEnable.Length == 0)
            return;

        if (_id < objsToEnable.Length)
            objsToEnable[_id].SetActive(true);
    }
}
