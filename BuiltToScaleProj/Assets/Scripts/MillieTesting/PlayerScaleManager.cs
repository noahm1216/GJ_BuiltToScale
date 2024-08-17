using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleManager : MonoBehaviour
{
    public GameObject player;

    private TPC characterControllerScript;

    public enum PlayerScale
    {
        Small,
        Medium,
        Large
    }

    public PlayerScale playerScale;

    public static PlayerScaleManager Instance;
    
    [HideInInspector] public bool isSmall;
    [HideInInspector] public bool isMedium;
    [HideInInspector] public bool isLarge;

    private Collider playerCollider;
    private CharacterController playerController;

    public LayerMask smallLayer;
    public LayerMask mediumLayer;
    public LayerMask largeLayer;

    public MeshRenderer playerColor;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        playerController = player.GetComponent<CharacterController>();
        characterControllerScript = player.GetComponent<TPC>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerScale)
        {
            case PlayerScale.Small:
                player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(.5f, .5f, .5f), Time.deltaTime/.2f);
                isSmall = true;
                isMedium = false;
                isLarge = false;
                playerController.excludeLayers = smallLayer;
                playerColor.material.color = Color.red;
                characterControllerScript.jumpHeight = .5f;
                characterControllerScript.moveSpeed = 8f;
                break;
            case PlayerScale.Medium:
                player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(1f, 1f, 1f), Time.deltaTime/.2f);
                isSmall = false;
                isMedium = true;
                isLarge = false;
                playerController.excludeLayers = mediumLayer;
                playerColor.material.color = Color.green;
                characterControllerScript.jumpHeight = 2f;
                characterControllerScript.moveSpeed = 5f;
                break;
            case PlayerScale.Large:
                player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(2f, 2f, 2f), Time.deltaTime/.2f);
                isSmall = false;
                isMedium = false;
                isLarge = true;
                playerController.excludeLayers = largeLayer;
                playerColor.material.color = Color.blue;
                characterControllerScript.jumpHeight = 4f;
                characterControllerScript.moveSpeed = 2f;
                break;
        }
    }
}
