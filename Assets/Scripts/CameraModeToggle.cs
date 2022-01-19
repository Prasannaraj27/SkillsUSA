using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraModeToggle : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    bool followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>().GetInRunningMode() || followPlayer)
        {
            virtualCamera.Follow = FindObjectOfType<Player>().transform;
        }
        else
        {
            virtualCamera.Follow = null;
        }
    }

    public void SetFollowPlayer(bool tOf)
    {
        followPlayer = tOf;
    }
}
