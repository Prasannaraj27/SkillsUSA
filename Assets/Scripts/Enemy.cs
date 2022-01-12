using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;

    [SerializeField] bool moveBackAndForth;
    [SerializeField] bool moveUpAndDown;
    [SerializeField] float movementSpeed = 5;

    [Header("xpos for back-forth\nypos for up-down")]
    [SerializeField] float pos1;
    [SerializeField] float pos2;

    float directionFacing = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveBackAndForth)
        {
            if (transform.position.x >= pos2)
            {
                directionFacing = -1;
            }
            else if (transform.position.x <= pos1)
            {
                directionFacing = 1;
            }
            transform.localScale = new Vector3(directionFacing, 1, 1);
            enemyRigidbody.velocity = new Vector2(directionFacing * movementSpeed, enemyRigidbody.velocity.y);
        }
        
    }
}
