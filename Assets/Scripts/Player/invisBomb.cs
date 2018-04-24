using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisBomb : MonoBehaviour {

    public GameObject bomb;
    public float CD;
    public float invisTime;
    public bool isInvis;

    bool offCD;
    float cdTimer;
    Material playerMat;
    Color defCol;
    Color invisCol;
    

	// Use this for initialization
	void Start () {
        playerMat = transform.parent.Find("Player").GetComponent<Renderer>().material;
        defCol = new Color(1, 1, 1, 1);
        invisCol = new Color(0.4f, 0.4f, 0.4f, 0.4f);
        offCD = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(cdTimer <= Time.time - CD)
        {
            offCD = true;
        }
		
        if(offCD && Input.GetButtonDown("Bomb"))
        {
            dropBomb();
        }
        
	}

    void dropBomb()
    {
        offCD = false;

        cdTimer = Time.time;

        Vector3 dropPos = transform.parent.transform.position; //get player position
        dropPos.y = 0; //Will always spawn in floor

        Instantiate(bomb, dropPos,Quaternion.identity); //instantiate the bomb at the players feet, with 0 rotation (not that rotation would change anything)

        StartCoroutine(goInvis());


    }

    IEnumerator goInvis() //method that changes the isInvis variable which is then read from to disable pathing on enemies
    {
        isInvis = true;

        playerMat.SetColor("_Color",invisCol); 

        yield return new WaitForSeconds(invisTime);

        isInvis = false;

        playerMat.SetColor("_Color", defCol);

        yield break;
    }
}
