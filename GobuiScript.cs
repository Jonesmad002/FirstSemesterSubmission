using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobuiScript : MonoBehaviour
{
    // Connects to SharedPlayerActions script
    public SharedPlayerActions parent;

    // Connects to the Animator component
    private Animator anim;

    // This is currently unused
    public int hp;

    // Controls how fast the sprite is moved
    public int speed;

    // Called as the script is loading
    private void Awake()
    {
        // Assigns varibles their items
        anim = GetComponent<Animator>();
        parent = GameObject.FindGameObjectWithTag("SharedPlayer").GetComponent<SharedPlayerActions>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is moving they will change to their walking animation
        anim.SetFloat("isMoving", parent.move);

        // Triggers attack animation when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Attack");
        }
    }

    // Moves the sprite based on the speed varible
    private void FixedUpdate()
    {
        parent.MoveSprite(speed);
    }
}
