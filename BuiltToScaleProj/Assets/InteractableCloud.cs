using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractableCloud : MonoBehaviour
{
    int ClickCounter = 0;
    bool canclick = true;
    public GameObject Key;

    private void OnMouseDown()
    {
        if (ClickCounter < 20 && canclick)
        {
            StartCoroutine(Shake());
            ClickCounter++;
        }
        else if (ClickCounter == 20 && canclick)
        {
            canclick = false;
            Key.SetActive(true);
            StartCoroutine(KeyMove());
        }
    }

    IEnumerator Shake()
    {
        canclick = false;
        Vector3 OriginalPosition = transform.position;
        for (int i = 0; i< 10; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position += new Vector3(Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f));
        }
        transform.position = OriginalPosition;
        canclick = true;
    }

    IEnumerator KeyMove()
    {
        Vector3 OriginalPos = Key.transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < 1)
        {
            Key.transform.position = Vector3.Lerp(OriginalPos, OriginalPos - new Vector3(0, 0.5f, 0), elapsedTime / 1);
            elapsedTime += Time.deltaTime;
        }
        yield return null;
    }
}
