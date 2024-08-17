using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioMixer audioMixer;
    public AudioMixerGroup MX1;
    public AudioMixerGroup MX2;

    public float FadeDuration = 1f;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fade(audioMixer, MX1, MX2));
        }
    }

    public IEnumerator Fade(AudioMixer mixer, AudioMixerGroup groupToFadeOut, AudioMixerGroup groupToFadeIn)
    {
        float currentTime = 0;
        string fadingOutParam = GetMixerGroupVolumeParameter(groupToFadeOut);
        string fadingInParam  = GetMixerGroupVolumeParameter(groupToFadeIn);

        while (currentTime < FadeDuration)
        {
            currentTime += Time.deltaTime;
            float newFadingOutVol = Mathf.Lerp(0, -80, currentTime / FadeDuration);
            float newFadingInVol  = Mathf.Lerp(-80, 0, currentTime / FadeDuration);
            mixer.SetFloat(fadingOutParam, newFadingOutVol);
            mixer.SetFloat(fadingInParam, newFadingInVol);
            yield return null;
        }
        yield break;
    }

    // Takes an Audio Mixer Group and returns its respective exposed volume paramter name
    public string GetMixerGroupVolumeParameter(AudioMixerGroup group)
    {
        if (group.name == "MX1") return "Volume_MX1";
        else if (group.name == "MX2") return "Volume_MX2";
        return "null";
    }
}
