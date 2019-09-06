using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetController : MonoBehaviour
{
    public List<GameObject> positions = new List<GameObject>();
    public List<Sprite> helmetSprites = new List<Sprite>();

    private Vector3 startPosition;
    private int currentPosition;
    public float spriteScaleX = 7.0f;
    public float spriteScaleY = 9.0f;

    private SpriteRenderer spriteRenderer;
    //private float startPostition = position[0.];
    // Start is called before the first frame update

    private void OnEnable()
    {
        ButtonInput.PressLeft += pressedLeft;
        ButtonInput.PressRight += pressedRight;
    }

    private void OnDisable()
    {
        ButtonInput.PressLeft -= pressedLeft;
        ButtonInput.PressRight -= pressedRight;
    }
    private void Start()
    {
        currentPosition = 0;
        startPosition = positions[0].transform.position;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        GoToStart();
    }

    // Update is called once per frame



    public void pressedLeft()
    {
        if (currentPosition > 0)
        {
        currentPosition --;
        movePosition(currentPosition);
        }

        


    }

    public void pressedRight()
    {
        if (currentPosition == positions.Count -1)
        {
            GoToStart();
        }
        else 
        {
            currentPosition ++;
            movePosition(currentPosition);
        }
        

    }
    
    private void movePosition(int position)
    {
        transform.position = positions[position].transform.position;
        UpdateSprite(position);
        

    }
    private void GoToStart()
    {
        
        if (positions != null)
        {
        transform.position = startPosition;
        currentPosition = 0;
       // spriteRenderer.sprite = helmetSprites[0];
       // transform.localScale = new Vector3(spriteScaleX, spriteScaleY, 1);
       UpdateSprite(currentPosition);
        
        }
    }

    private void UpdateSprite(int position)
    {
        if (position <= helmetSprites.Count)
        {
        spriteRenderer.sprite = helmetSprites[position];
        transform.localScale = new Vector3(spriteScaleX, spriteScaleY, 1);
        }
    }
    


}
