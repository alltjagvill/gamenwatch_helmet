using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifes = 3;
    public int score = 0;
    public float doorClosedDelay = 100.0f;
    public float doorClosedTime = 3.0f;
    float lastClosedDoor;
    public GameObject closedDoor;
    public TextMeshPro scoreText;


    private bool doorClosed = false;


    public bool isDoorClosed()
    {
        return doorClosed;
    }
        
     

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > lastClosedDoor + doorClosedDelay)
        {
            StartCoroutine (CloseDoor());
        }
    }
    IEnumerator CloseDoor()
    {
        doorClosed = true;
        closedDoor.SetActive(true);
        lastClosedDoor = Time.time;
        yield return new WaitForSeconds(doorClosedTime);
        doorClosed = false;
        closedDoor.SetActive(false);

    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }
}
