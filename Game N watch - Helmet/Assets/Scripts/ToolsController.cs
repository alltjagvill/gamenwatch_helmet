using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsController : MonoBehaviour
{
    public List<Transform> spawn0 = new List<Transform>();
    public List<Transform> spawn1 = new List<Transform>();
    public List<Transform> spawn2 = new List<Transform>();
    public List<Transform> spawn3 = new List<Transform>();
    public List<Transform> spawn4 = new List<Transform>();

    public int currentPosition = 0;

    public float moveToolDelay = 1.0f;
    private Vector3 startPosition;

    private bool touchedGround = false;

    void Start()
    {
        //startPosition = spawn0[0].transform.position;
        //MoveToNextPosition();

        Debug.Log("Spawn0 length: " + spawn0.Count);
        UpdatePosition();
        StartCoroutine(MoveTool());
    }

    IEnumerator MoveTool()
    {
        while (!touchedGround)
        {
            yield return new WaitForSeconds(moveToolDelay);
            MoveToNextPosition();
        }

    }


    private void MoveToNextPosition()
    {
        currentPosition++;
        Debug.Log("Current position: " + currentPosition);
        if (currentPosition >= spawn0.Count)
        {
            DestroyTool();
        }
        else
        {
            UpdatePosition();
        }

    }
    
    private void DestroyTool()
    {
        GameObject toolParent = transform.parent.gameObject;
        Destroy(toolParent);
    }

    private void UpdatePosition()
    {
        transform.position = spawn0[currentPosition].transform.position;

    }
}
