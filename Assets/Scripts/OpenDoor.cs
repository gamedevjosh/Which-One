using UnityEngine;
using System;
using System.Collections;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject doorClosePosition;
    public GameObject doorOpenPosition;

    public Vector3 openPosition;

    public bool isOpen = true;
    public bool timedDoor = false;
    public bool canTrigger = true;

    public float speed;
    public float timer;
    public float doorActiveTime;

    private void Start()
    {
        StartCoroutine(TriggerDoor());
    }

    private void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1") || other.CompareTag("Player 2") && canTrigger)
        {
            canTrigger = false;
            if(timedDoor == true)
            {
                StartCoroutine(TriggerTimedDoor());
            }
            else
            {
                StartCoroutine(TriggerDoor());
            }
        }

        
    }

    public IEnumerator TriggerDoor()
    {
        if (isOpen)
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(doorOpenPosition.transform.position, doorClosePosition.transform.position, timer);
            isOpen = false;
        }
        else
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(doorClosePosition.transform.position, openPosition, timer);
            isOpen = true;
        }
        yield return new WaitForSeconds(1f);
        timer = 0;
        canTrigger = true;
        yield return null;
    }

    public IEnumerator TriggerTimedDoor()
    {
        if (isOpen)
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(doorOpenPosition.transform.position, doorClosePosition.transform.position, timer);
            isOpen = false;
        }
        else
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(doorClosePosition.transform.position, openPosition, timer);
            isOpen = true;
        }
        yield return new WaitForSeconds(doorActiveTime);
        if (isOpen)
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(doorOpenPosition.transform.position, doorClosePosition.transform.position, timer);
            isOpen = false;
        }
        else
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(doorClosePosition.transform.position, openPosition, timer);
            isOpen = true;
        }
        timer = 0;
        canTrigger = true;
        yield return null;
    }
}