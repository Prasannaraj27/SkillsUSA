using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    BoxCollider2D feetCollider;

    // SET TO TRUE WHEN DONE TESTING
    [SerializeField] bool inRunningMode = true; // Important: this is the mode the player is in
    bool canSwitchMode;

    // Variables that can be changed outside of the code
    [SerializeField] float runningMovementSpeed = 10;
    [SerializeField] float exploringMovementSpeed = 5;
    [SerializeField] float jumpSpeed = 5;

    [SerializeField] float runToExploreWaitTime = 5;
    [SerializeField] float exploreToRunWaitTime = 1;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        canSwitchMode = true;
    }

    void Update()
    {
        // Character movement either in Running Mode or Exploring Mode
        if (inRunningMode) { playerRigidbody.velocity = new Vector2(runningMovementSpeed, playerRigidbody.velocity.y); }
        else { playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * exploringMovementSpeed, playerRigidbody.velocity.y); }
        
        // Direction character faces based on movement
        if (!inRunningMode && Input.GetAxisRaw("Horizontal") != 0) { transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1); }
        else if (inRunningMode) { transform.localScale = new Vector3(1, 1, 1); }

        // Checks to see if touching ground, will allow to jump if player is touching it
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && Input.GetAxisRaw("Jump") == 1)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpSpeed);
        }

        // Checks to see if you can switch mode and if you press switch mode button (space)
        if (canSwitchMode && Input.GetAxisRaw("Switch Modes") != 0) 
        {
            canSwitchMode = false;
            inRunningMode = !inRunningMode;
            Debug.Log("In Running Mode: " + inRunningMode);
            StartCoroutine(SetModeSwitchTimer());
        }
    }

    // Sets timer to limit switching between modes
    IEnumerator SetModeSwitchTimer()
    {
        if (inRunningMode)
        {
            yield return new WaitForSeconds(runToExploreWaitTime);
        }
        else
        {
            yield return new WaitForSeconds(exploreToRunWaitTime);
        }
        canSwitchMode = true;
    }

    // Allows for other gameobjects to see what mode the player is in
    public bool GetInRunningMode()
    {
        return inRunningMode;
    }
}
