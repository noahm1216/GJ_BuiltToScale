using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpLightColor : MonoBehaviour
{
    public Light lightToChange;
    public float lerpSpeed = 1;
    public Color originalColor, secondColor;
    private Color lerpColor;
    

    void Start()
    {
        lightToChange.color = originalColor;
    }

    void Update()
    {
        lerpColor = Color.Lerp(originalColor, secondColor, Mathf.PingPong(Time.time * lerpSpeed, 1));
        lightToChange.color = lerpColor;
    }
}
