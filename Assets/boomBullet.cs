using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomBullet : MonoBehaviour {

    float windupTimer;

	// Use this for initialization
	void Start () {
        windupTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    List<GameObject> enemyList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        BoomerangGun boomerangGun = GameObject.Find("GunBarrelEnd").GetComponent<BoomerangGun>();

        if (other.CompareTag("Player") && windupTimer < Time.time - 1f)
        {
            boomerangGun.bulletReturned();
        }

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null && !enemyList.Contains(other.gameObject))
        {
            int damage = boomerangGun.getDamage();
            if(damage != 0)
            {
                Debug.Log("dealt damage!");
                enemyList.Add(other.gameObject);
                enemyHealth.TakeDamage(boomerangGun.getDamage());
            }
            
        }
    }
}
