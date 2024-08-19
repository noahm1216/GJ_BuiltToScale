using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Cinemachine;

public class Dimension : MonoBehaviour
{
    public Camera MainCamera;
    public Camera TransitionCamera;

    public CinemachineVirtualCamera MainVCAM;
    public CinemachineVirtualCamera TransitionVCAM;

    public List<Dimension> ZoomInDimensions;
    public Dimension ZoomOutDimension;

    public AudioMixerGroup MixerGroup;
}
