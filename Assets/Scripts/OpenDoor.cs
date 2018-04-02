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

    public float speed;
    public float timer;

    private void Start()
    {
        if (isOpen)
        {
            StartCoroutine(DoorOpen());
        }
        else
        {
            StartCoroutine(DoorClose());
        }
        doorOpenPosition.transform.position = door.transform.position;
        openPosition = door.transform.position;
    }

    private void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
        if (!isOpen && other.CompareTag("Player 1") || !isOpen && other.CompareTag("Player 2"))
        {
            isOpen = true;
            StartCoroutine(DoorOpen());
        }

        else if(isOpen && other.CompareTag("Player 1") || isOpen && other.CompareTag("Player 2"))
        {
            isOpen = false;
            StartCoroutine(DoorClose());
        }
    }

    public IEnumerator DoorOpen()
    {
        timer += Time.deltaTime;
        door.transform.position = Vector3.Lerp(doorOpenPosition.transform.position, doorClosePosition.transform.position, timer);
        yield return new WaitForSeconds(3f);
        timer = 0;
        yield return null;
    }

    public IEnumerator DoorClose()
    {
        timer += Time.deltaTime;
        door.transform.position = Vector3.Lerp(doorClosePosition.transform.position, openPosition, timer);
        yield return new WaitForSeconds(3f);
        timer = 0;
        yield return null;
    }


    //IEnumerator doorOpen()
    //{
    //    timer += Time.deltaTime;
    //    Debug.Log("Door open Coroutine started");
    //    door.transform.position = Vector3.Lerp(openPosition, doorClose.transform.position, timer);
    //    yield return new WaitForSeconds(1);
    //    openDoor = false;
    //    isClosed = true;
    //    Debug.Log("Open door is false");
    //    timer = 0;
    //    yield return null;
    //}

    //IEnumerator doorCloseFunc()
    //{
    //    timer += Time.deltaTime;
    //    Debug.Log("Door close Coroutine started");
    //    door.transform.position = Vector3.Lerp(doorClose.transform.position, openPosition, timer);
    //    yield return new WaitForSeconds(1);
    //    closeDoor = false;
    //    isOpen = true;
    //    isClosed = false;
    //    Debug.Log("close door is false");
    //    timer = 0;
    //    yield return null;
    //}
}