using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    invisBomb invisBomb;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        invisBomb = player.transform.Find("GunBarrelEnd").GetComponent<invisBomb>();

    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !invisBomb.isInvis)
        {
            nav.enabled = true;
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
