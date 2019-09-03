using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetController : MonoBehaviour
{
    public List<GameObject> positions = new List<GameObject>();

    Vector3 startPosition;
    
    //private float startPostition = position[0.];
    // Start is called before the first frame update
    void Start()
    {
        startPosition = positions[0].transform.position;
        GoToStart();
    }

    // Update is called once per frame


    private void GoToStart()
    {
        
        if (positions != null)
        {
        transform.position = startPosition; 
        Debug.Log("Position: " + startPosition);
        Debug.Log("Number in list: " + positions.Count);
        }
    }
    


}
