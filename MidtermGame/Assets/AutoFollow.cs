using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AutoFollow : MonoBehaviour
{

    private void Awake()
    {
        // Get the Cinemachine Virtual Camera component
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();

        // Find the player GameObject by tag and assign it to the Follow property
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            virtualCamera.Follow = player.transform;
        }
        else
        {
            Debug.LogError("Players gone bro.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
