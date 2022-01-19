using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxController : MonoBehaviour
{
    [SerializeField] GameObject[] checkpoints;
    GameObject checkpointToTeleportTo;
    Player player;
    Fog fog;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        fog = FindObjectOfType<Fog>();
        //fog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            player.transform.position = checkpoints[0].transform.position;
            StartCoroutine(player.HandleTeleport());
        }
        else if (Input.GetKeyDown("2"))
        {
            player.transform.position = checkpoints[1].transform.position;
            StartCoroutine(player.HandleTeleport());
        }
        else if (Input.GetKeyDown("3"))
        {
            player.transform.position = checkpoints[2].transform.position;
            StartCoroutine(player.HandleTeleport());
        }

        else if (Input.GetKeyDown("f"))
        {
            fog.SetFogActive(!fog.IsFogActive());
        }
    }
}
