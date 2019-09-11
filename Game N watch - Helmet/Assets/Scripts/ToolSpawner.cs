using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject toolPrefab;

  public float spawnDelay = 4.0f;
  private float lastSpawnTime;

  public List<Transform> spawn0 = new List<Transform>();
  public List<Transform> spawn1 = new List<Transform>();
  public List<Transform> spawn2 = new List<Transform>();
  public List<Transform> spawn3 = new List<Transform>();
  public List<Transform> spawn4 = new List<Transform>();

  private List<List<Transform>> spawnPoints = new List<List<Transform>>();
  private int randomSpawnPoint;

  public GameManager gameManager;


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
    if (Time.time > lastSpawnTime + spawnDelay)
    {
        spawnTool();
    }
  }



  private void spawnTool()
  {
    lastSpawnTime = Time.time;
    randomSpawnPoint = Random.Range(0, spawnPoints.Count);
    List<Transform> currentSpawnPoint = spawnPoints[randomSpawnPoint];    
    GameObject tool = Instantiate(toolPrefab);
    ToolsController toolsController = tool.GetComponent<ToolsController>();
    
    toolsController.spawnPoint = currentSpawnPoint;
  }

 
}
