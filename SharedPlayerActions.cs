using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SharedPlayerActions : MonoBehaviour
{
    // Check which way the player sprite faces
    private bool faceing = true;

    // Gets the movement for animations, used for other scripts
    public float move = 0;

    // Connected to sprite movement
    private Vector2 movement;

    // Connects to Rigidbody component
    private Rigidbody2D rb;

    // Called as script is loading
    private void Awake()
    {
        // Grabs game components
        rb = GetComponent<Rigidbody2D>();
    }

    // When WASD is pressed, the player moves and/or changes direction
    private void OnWalks(InputValue value)
    {
        movement = value.Get<Vector2>();

        // This varible is sent to other scripts for animation purposes
        move = Mathf.Abs(movement.x) + Mathf.Abs(movement.y);

        //Changes the direction sprite is facing if needed
        if (movement.x > 0 && faceing == false)
        {
            gameObject.transform.Rotate(0, 180, 0);
            faceing = true;
        }else if(movement.x < 0 && faceing == true){
            gameObject.transform.Rotate(0, 180, 0);
            faceing = false;
        }
      
    }

    // Moves the player based on the input in OnWalks
    public void MoveSprite(int sp)
    {
        rb.MovePosition(rb.position + movement * sp * Time.fixedDeltaTime);
    }


}
