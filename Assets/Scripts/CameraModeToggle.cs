using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraModeToggle : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>().GetInRunningMode())
        {
            virtualCamera.Follow = FindObjectOfType<Player>().transform;
        }
        else
        {
            virtualCamera.Follow = null;
        }
    }
}
