using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangGun : MonoBehaviour {

    public int damageIn = 80;
    public float range = 10;
    public GameObject bullet;
    public float bulletSpeed;
    public float travelTime;
    public float recallSpeed;

    bool isOut;
    bool isRecall;
    ParticleSystem gunParticles;
    AudioSource gunAudio;
    Light gunLight;
    GameObject firedBullet;
    Rigidbody firedBulletRB;

    // Use this for initialization
    void Awake () {
        gunParticles = GetComponent<ParticleSystem>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2") && isOut)
        {
            isRecall = true;
        }
        if (Input.GetButtonDown("Fire2") && !isOut)
        {
            Shoot();
        }
        

        if(isRecall)
        {
            Recall();
        }

	}

    void Shoot()
    {
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();
        
        isOut = true;

        firedBullet = Instantiate(bullet,transform.position,transform.rotation);
        firedBulletRB = firedBullet.GetComponent<Rigidbody>();
        firedBulletRB.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

    }

    void Recall()
    {

        Vector3 returnVector = transform.parent.position - firedBullet.transform.position;
        returnVector.Normalize();

        firedBulletRB.AddForce(returnVector * recallSpeed);

        

    }
    public Vector3 knockback;
    public void bulletReturned()
    {
        //Vector3 knockback = firedBulletRB.velocity;
        knockback = firedBulletRB.velocity;
        Destroy(firedBullet);
        isOut = false;
        isRecall = false;
        GetComponentInParent<Rigidbody>().velocity = knockback;

    }

    public int getDamage()
    {
        if(!isRecall)
        {
            return 0;
        }
        else
        {
            return damageIn;
        }
    }


}
