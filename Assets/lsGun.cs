using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lsGun : MonoBehaviour {

    public GameObject lsBullet;

    bool offCD;
    float cdTimer;
    public float CD;


	// Use this for initialization
	void Start () {
        offCD = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (cdTimer <= Time.time - CD)
        {
            offCD = true;
        }

        if(offCD && Input.GetButtonDown("LifeSteal"))
        {
            Fire();
        }

    }

    void Fire()
    {
        offCD = false;
        cdTimer = Time.time;

        Instantiate(lsBullet,transform.position,transform.parent.rotation);
    }

}
