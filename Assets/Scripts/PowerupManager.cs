using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public bool isReversePowerup;
    public bool movementEnabled = false;

    public GameObject player1;
    public GameObject player2;

    public void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1") || other.CompareTag("Player 2"))
        {
            if (isReversePowerup)
            {
                ReverseMovement();
            }
        }

        if (other.CompareTag("Player 1") && !movementEnabled)
        {
            player2.GetComponent<PlayerManager>().enabled = true;
        }
    }

    public void ReverseMovement()
    {
        player1.GetComponent<PlayerManager>().moveSpeed = player1.GetComponent<PlayerManager>().moveSpeed * -1;
    }
}
