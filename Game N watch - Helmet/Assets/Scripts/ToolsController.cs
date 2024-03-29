﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsController : MonoBehaviour
{

    public delegate void Tool();
    public static event Tool OnHelmetKill;

    public int currentPosition = 0;

    public float moveToolDelay = 1.0f;
    private Vector3 startPosition;

    private bool touchedGround = false;
    public List<Transform> spawnPoint = new List<Transform>();

    public LayerMask layerMask;
    
    void OnEnable()
    {
        GameManager.OnGameOver += DestroyTool;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= DestroyTool;
    }
    void Start()
    {
     
        //startPosition = spawn0[0].transform.position;
        //MoveToNextPosition();

   //     Debug.Log("Spawn0 length: " + spawn0.Count);
   //Debug.Log("Listpos: " + spawnPoint[0].position);
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
        
        if (currentPosition >= spawnPoint.Count)
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
        //GameObject toolParent = transform.parent.gameObject;
        Destroy(transform.gameObject);
    }

    private void UpdatePosition()
    {
        transform.position = spawnPoint[currentPosition].transform.position;
        if(spawnPoint[currentPosition].gameObject.tag == "HitPosition")
        {
            RaycastHit2D helmetHit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);

            if (helmetHit.collider != null)
            {
                if (OnHelmetKill != null)
                {
                    OnHelmetKill();
                }
            }
        }

    }

    
}
