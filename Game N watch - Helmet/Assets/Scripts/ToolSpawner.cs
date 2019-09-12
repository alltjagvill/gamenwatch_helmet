using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject toolPrefab;

  public float spawnDelay = 4.0f;
  private float lastSpawnTime;
  public float scoreDelayInterval = 0.01f;
  private bool enableSpawn = true;

  public List<Transform> spawn0 = new List<Transform>();
  public List<Transform> spawn1 = new List<Transform>();
  public List<Transform> spawn2 = new List<Transform>();
  public List<Transform> spawn3 = new List<Transform>();
  public List<Transform> spawn4 = new List<Transform>();

  private List<List<Transform>> spawnPoints = new List<List<Transform>>();
  private int randomSpawnPoint;

  public GameManager gameManager;


  void OnEnable()
    {
        GameManager.OnGameOver += DisableSpawn;
    }

  void OnDisable()
    {
        GameManager.OnGameOver -= DisableSpawn;
    }
    void Start()
  {
    if (toolPrefab == null)
    return;

    
    spawnPoints.Add(spawn0);
    spawnPoints.Add(spawn1);
    spawnPoints.Add(spawn2);
    spawnPoints.Add(spawn3);
    spawnPoints.Add(spawn4);

    spawnTool();
  }

  void Update()
  {
    int scoreDelay = gameManager.getScore();
    float punishDelay = scoreDelay * scoreDelayInterval;
        if (Time.time > lastSpawnTime + (spawnDelay - punishDelay))
    {
        spawnTool();
    }
  }



  private void spawnTool()
  {
        if (enableSpawn == true)
        {
            lastSpawnTime = Time.time;
            randomSpawnPoint = Random.Range(0, spawnPoints.Count);
            List<Transform> currentSpawnPoint = spawnPoints[randomSpawnPoint];
            GameObject tool = Instantiate(toolPrefab);
            ToolsController toolsController = tool.GetComponent<ToolsController>();

            toolsController.spawnPoint = currentSpawnPoint;
        }
  }

    private void DisableSpawn()
    {
        enableSpawn = false;
    }
}
