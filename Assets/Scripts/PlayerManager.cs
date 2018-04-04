using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public float moveSpeed;
    public bool isReversed = false;

    private void Start()
    {
        p1 = GameObject.Find("Player 1");
        p2 = GameObject.Find("Player 2");
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Reverse()
    {
        isReversed = true;
    }
    public void Syncronize()
    {
        isReversed = false;
    }

    void Movement()
    {
        if (isReversed == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

            p1.transform.Translate(horizontal, vertical, 0);
            p2.transform.Translate(-horizontal, -vertical, 0);
        }
        else
        {
            float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

            p1.transform.Translate(horizontal, vertical, 0);
            p2.transform.Translate(horizontal, vertical, 0);
        }
    }
}
