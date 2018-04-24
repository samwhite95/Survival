using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisBombDet : MonoBehaviour {

    
    public float bombTimer;

    bool detonated;
    Collider col;
    MeshRenderer damageVisual;

	// Use this for initialization
	void Start () {
        col = GetComponent<SphereCollider>();
        col.enabled = false;
        damageVisual = transform.Find("damageVis").GetComponent<MeshRenderer>();
        damageVisual.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!detonated)
        {
            StartCoroutine(bomb());
            detonated = true;
        }
	}

    IEnumerator bomb()
    {
        yield return new WaitForSeconds(bombTimer);

        col.enabled = true;
        damageVisual.enabled = true;
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(100);
        }
        
    }

}
