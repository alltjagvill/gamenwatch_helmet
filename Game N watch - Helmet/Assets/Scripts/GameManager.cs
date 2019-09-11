using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void GameManagerEvent();
    public static event GameManagerEvent OnGameOver;
    public int lifes = 3;
    public int score = 0;
    public float doorClosedDelay = 100.0f;
    public float doorClosedTime = 3.0f;
    float lastClosedDoor;
    public GameObject closedDoor;
    public TextMeshPro scoreText;


    private bool doorClosed = false;


    void OnEnable()

    {
        ToolsController.OnHelmetKill += RemoveLife;
    }
        
    void OnDisable()
    {
        
            ToolsController.OnHelmetKill -= RemoveLife;
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
        Debug.Log("Door closed: " + doorClosed);
        lastClosedDoor = Time.time;
        yield return new WaitForSeconds(doorClosedTime);
        doorClosed = false;
        Debug.Log("Door closed: " + doorClosed);
        closedDoor.SetActive(false);

    }

    public bool isDoorClosed()
    {
        return doorClosed;
    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }

    public int getScore()
    {
        return score;
    }

    private void RemoveLife()
    {
        if (lifes <= 1)
        {
            GameOver();
        }
        else
        {
            lifes--;
            Debug.Log("Lifes: " + lifes);
        }
    }

    private void GameOver()
    {
        if (OnGameOver != null) 
        {
            OnGameOver();
        }

        Debug.Log("Game Over!");
        Debug.Log("Lifes: " + lifes);
    }
}
