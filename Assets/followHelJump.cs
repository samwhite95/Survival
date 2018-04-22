using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followHelJump : MonoBehaviour {
    RectTransform rectTrans;
    Vector3 helVector;
    Vector3 barVector;

    // Use this for initialization
    void Start () {
        rectTrans = GetComponent<RectTransform>();
	}

    // Update is called once per frame



	void Update () {
        barVector = Vector3.zero;
        helVector = transform.parent.parent.Find("Trunk1").transform.position;

        barVector.y = helVector.y + 1.7f;

        rectTrans.anchoredPosition3D = barVector;

	}
}
