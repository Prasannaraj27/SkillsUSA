using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    Rigidbody2D fogRigidbody;

    Player player;

    //[SerializeField] bool settleIn;
    [SerializeField] float timeToSettleIn = 3;
    [SerializeField] float movementSpeed = 1;

    bool settlingIn = false;
    bool fogActive;

    // Start is called before the first frame update
    void Start()
    {
        fogRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fogActive)
        {
            settlingIn = false;
            transform.position = new Vector3(-25, 0, 0);
            return;
        }

        if (!player.GetInRunningMode() && !settlingIn && !player.gameJustStarted && !player.IsKnockedOut())
        {
            settlingIn = true;
            transform.position = new Vector3(player.transform.position.x - 17.5f, player.transform.position.y + 1.25f);
            StartCoroutine(SettleIn());
        }
        else if (player.GetInRunningMode() || player.IsKnockedOut())
        {
            settlingIn = false;
            transform.position = new Vector3(-25, 0, 0);
            //transform.position = new Vector3(player.transform.position.x - 17.5f, player.transform.position.y + 1.25f);
        }
    }

    IEnumerator SettleIn()
    {
        yield return new WaitForSeconds(timeToSettleIn);
        fogRigidbody.velocity = new Vector2(movementSpeed, 0);

    }

    public void SetFogActive(bool tOf)
    {
        fogActive = tOf;
    }

    public bool IsFogActive()
    {
        return fogActive;
    }
}
