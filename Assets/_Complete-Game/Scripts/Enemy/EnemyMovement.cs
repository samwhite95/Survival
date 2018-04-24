﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        GameObject player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
        invisBomb invisBomb;

        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            invisBomb = player.transform.Find("GunBarrelEnd").GetComponent<invisBomb>();
        }


        void Update ()
        {
            // If the enemy and the player have health left...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !invisBomb.isInvis)
            {

                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination (player.transform.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }



            
        }
    }
}