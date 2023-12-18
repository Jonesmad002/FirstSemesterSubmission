using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedEnemyActions : MonoBehaviour
{
    // The ammount of damage that can be taken before the enemy is defeated
    private int health = 5;

    // Connects to Animator component
    private Animator anim;

    // Called as the script is loading
    void Awake()
    {
        // Assigns varibles their items
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy has no more health the defeat animation is played
        if (health < 0)
        {
            anim.SetBool("IsDefeat", true);
        }
    }

    // When the enemy is hit its health is subtracted by the damage recived and the hit animation is played
    public void Hit(int pow)
    {
        health -= pow;
        anim.SetTrigger("IsHit");
    }

}
