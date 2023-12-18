using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobuiWeaponScript : MonoBehaviour
{
    // Connects to Animator component
    private Animator anim;

    // Connects to other scripts
    public SharedEnemyActions attack;

    // The ammount of damage the attack does
    private int pow = 2;

    // Called as the script is loading
    void Awake()
    {
        // Assigns varibles their items
        anim = GetComponent<Animator>();
        attack = GameObject.FindGameObjectWithTag("ShareEnemy").GetComponent<SharedEnemyActions>();
    }

    // Update is called once per frame
    void Update()
    {
        // Plays swinging animation when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Swing");
            // The Animator automatically activates the collision trigger
        }
    }

    // When the player attacks and hits an enemy the enemy loses health equal to pow
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if item hit is an enemy
        if (collision.GetComponent<SharedEnemyActions>() != null)
        {
            attack = collision.GetComponent<SharedEnemyActions>();
            attack.Hit(pow);
        }
    }
}