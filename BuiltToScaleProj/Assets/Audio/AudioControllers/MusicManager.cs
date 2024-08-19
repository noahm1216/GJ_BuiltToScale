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
    public AudioMixerGroup MX_World1;
    public AudioMixerGroup MX_World2;
    public AudioMixerGroup MX_World3;
    public AudioMixerGroup MX_World4;
    public AudioMixerGroup MX_World5;
    public AudioMixerGroup MX_World6;

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
        else if (group.name == "World 1") return "World1_MX";
        else if (group.name == "World 2") return "World2_MX";
        else if (group.name == "World 3") return "World3_MX";
        else if (group.name == "World 4") return "World4_MX";
        else if (group.name == "World 5") return "World5_MX";
        else if (group.name == "World 6") return "World6_MX";
        else if (group.name == "World 7") return "World7_MX";
        return "null";
    }
}
