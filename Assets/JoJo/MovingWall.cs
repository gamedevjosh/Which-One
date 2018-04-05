using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {
    public float ChangeInX;
    public float ChangeInY;
    public float SpeedValue;
    public float RotationSpeed;
    private Vector3 InitialPosition;
    private Vector3 SecondaryPosition;
    private float BounceValue;
    public bool Rotate;
    public bool Reverse;
    
    
	// Use this for initialization
	void Start () {
        InitialPosition = this.gameObject.transform.position;
        SecondaryPosition = InitialPosition + new Vector3(ChangeInX, ChangeInY, 0);
	}
	
	// Update is called once per frame
	void Update () {
        BounceValue = Mathf.PingPong(Time.time, SpeedValue);
        this.gameObject.transform.position = Vector3.Lerp(InitialPosition, SecondaryPosition, BounceValue * (1 / SpeedValue));

        if (Rotate == true && Reverse == true)
        {
            this.gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed * 100);
        }
        if (Rotate == true && Reverse == false)
        {
            this.gameObject.transform.Rotate(Vector3.back * Time.deltaTime * RotationSpeed * 100);
        }

    }
}
