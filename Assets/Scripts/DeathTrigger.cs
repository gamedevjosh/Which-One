using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    GameObject p1;
    GameObject p2;
    Vector2 p1StartPosition;
    Vector2 p2StartPosition;

	// Use this for initialization
	void Start () {
        p1 = GameObject.Find("Player 1");
        p2 = GameObject.Find("Player 2");
        p1StartPosition = p1.transform.position;
        p2StartPosition = p2.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player 1") || collision.CompareTag("Player 2"))
        {
            p1.transform.position = p1StartPosition;
            p2.transform.position = p2StartPosition;
        }
    }

}
