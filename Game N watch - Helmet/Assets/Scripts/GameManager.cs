using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject gameOverSign;
    public TextMeshPro scoreText;
    public LifeController lifeController;
    private string mainScene = "Main";

    private bool isGameOver = false;
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

        lifeController.CreateLifes(lifes);
       
    }

    void Update()
    {
        if (Time.time > lastClosedDoor + doorClosedDelay && isGameOver == false)
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
            lifeController.RemoveLife();
        }
    }

    private void GameOver()
    {
        if (OnGameOver != null) 
        {
            OnGameOver();
            isGameOver = true;
            closedDoor.SetActive(false);
            gameOverSign.SetActive(true);
        }

        Debug.Log("Game Over!");
        Debug.Log("Lifes: " + lifes);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(mainScene);
    }

}
