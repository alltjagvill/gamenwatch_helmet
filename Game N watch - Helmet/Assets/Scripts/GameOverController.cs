using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;

    
    public void OnMouseDown()
    {
        gameManager.RestartGame();
    }

    
    
}
