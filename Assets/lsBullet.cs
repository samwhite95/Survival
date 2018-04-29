using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lsBullet : MonoBehaviour {

    Rigidbody rb;
    float lifeTimer;
    PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        lifeTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        

        if(lifeTimer < Time.time - 2f)
        {
            Destroy(gameObject);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(15);
            playerHealth.currentHealth += 15;
            if(playerHealth.currentHealth > 100)
            {
                playerHealth.currentHealth = 100;
            }
            playerHealth.healthSlider.value = playerHealth.currentHealth;
            Destroy(gameObject);
        }

        
    }
}
