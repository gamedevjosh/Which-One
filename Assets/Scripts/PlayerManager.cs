using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(horizontal, vertical,0);
    }
}
