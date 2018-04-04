using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject player;
    public bool ReversePowerup = false;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player 1");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1") || other.CompareTag("Player 2"))
        {
            if(ReversePowerup == false)
            {
                player.GetComponent<PlayerManager>().Syncronize();
            }
            else
            {
                player.GetComponent<PlayerManager>().Reverse();
            }
        }
    }
}
