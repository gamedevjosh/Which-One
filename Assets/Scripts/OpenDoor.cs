using UnityEngine;
using System;
using System.Collections;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject doorClose;
    public GameObject doorOpenPosition;

    public bool openDoor = false;
    public bool closeDoor = false;
    public bool isOpen;
    public bool isClosed;

    public float speed;

    private void Start()
    {
        doorOpenPosition.transform.position = door.transform.position;
    }

    private void Update()
    {
        if (openDoor)
        {
            StartCoroutine(doorOpen());
        }

        if (closeDoor)
        {
            StartCoroutine(doorCloseFunc());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
        if (isOpen && other.CompareTag("Player 1") || isOpen && other.CompareTag("Player 2"))
        {
            openDoor = true;
            isOpen = false;
            isClosed = false;
        }

        if(isClosed && other.CompareTag("Player 1") || isClosed && other.CompareTag("Player 2"))
        {
            closeDoor = true;
            isOpen = false;
        }
    }

    IEnumerator doorOpen()
    {
        Debug.Log("Door open Coroutine started");
        door.transform.position = Vector3.MoveTowards(door.transform.position, doorClose.transform.position *.95f, speed * Time.deltaTime);
        yield return new WaitForSeconds(1);
        openDoor = false;
        isClosed = true;
        Debug.Log("Open door is false");
        yield return null;
    }

    IEnumerator doorCloseFunc()
    {
        Debug.Log("Door close Coroutine started");
        door.transform.position = Vector3.MoveTowards(door.transform.position, doorClose.transform.position, -speed * Time.deltaTime);
        yield return new WaitForSeconds(1);
        closeDoor = false;
        isOpen = true;
        Debug.Log("close door is false");
        yield return null;
    }
}