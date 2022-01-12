using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // SET TO TRUE WHEN DONE TESTING
    [SerializeField] bool inRunningMode = true; // Important: this is the mode the player is in
    [SerializeField] int health = 3; // Important: this is the player health
    bool knockedOut = false; // Important: checks if player got knocked out and loses health
    [SerializeField] GameObject currentCheckpoint; // Important: this is the latest checkpoint the player passed
    [SerializeField] float waitTimeForRespawn = 1;
    [SerializeField] GameObject deathParticles;
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
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        canSwitchMode = true;
    }

    void Update()
    {
        if (health < 0) { health = 0; }

        if (knockedOut) { return; }

        // Character movement either in Running Mode or Exploring Mode
        if (inRunningMode) { playerRigidbody.velocity = new Vector2(runningMovementSpeed, playerRigidbody.velocity.y); }
        else { playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * exploringMovementSpeed, playerRigidbody.velocity.y); }
        
        // Direction character faces based on movement
        if (!inRunningMode && Input.GetAxisRaw("Horizontal") != 0) { transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1); }
        else if (inRunningMode) { transform.localScale = new Vector3(1, 1, 1); }

        if (Mathf.Abs(playerRigidbody.velocity.x) > 0) { animator.SetBool("isRunning", true); }
        else { animator.SetBool("isRunning", false); }

        // Checks to see if touching ground, will allow to jump if player is touching it
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && Input.GetAxisRaw("Jump") == 1)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpSpeed);
        }
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { animator.SetBool("inAir", true); }
        else { animator.SetBool("inAir", false); }

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
        //FindObjectOfType<PlayerModeUI>().UpdateModeText();
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

    public bool CanSwitchModes()
    {
        return canSwitchMode;
    }

    IEnumerator TakeDamageAndManageRespawn()
    {
        knockedOut = true;

        playerRigidbody.bodyType = RigidbodyType2D.Static;
        bodyCollider.enabled = false;
        feetCollider.enabled = false;
        health--;
        if (deathParticles)
        {
            var particle = Instantiate(deathParticles, new Vector3(transform.position.x, transform.position.y, -0.1f), Quaternion.identity) as GameObject;
            Destroy(particle, 1f);
        }
        yield return new WaitForSeconds(waitTimeForRespawn/2.0f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(waitTimeForRespawn/2.0f);
        if (isDead()) { yield break; }

        transform.position = new Vector3(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y, transform.position.z);
        yield return new WaitForEndOfFrame();
        bodyCollider.enabled = true;
        feetCollider.enabled = true;
        spriteRenderer.enabled = true;
        playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
        
        knockedOut = false;


        Debug.Log("Remaining health: " + health);
    }

    public bool isDead()
    {
        return (health <= 0);
    }

    public int getHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !knockedOut)
        {
            knockedOut = true;
            StartCoroutine(TakeDamageAndManageRespawn());
        }
        else if (other.tag == "Checkpoint")
        {
            currentCheckpoint = other.gameObject;
        }
    }

}
