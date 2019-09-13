using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    //Skapar en "lista" på vad som kan hända.
    //public enum Button
    //{
    //    left,
    //    right
    //}
    //private void OnMouseDown()
    //{

    //    if (PressLeft != null && button == Button.left) //Kollar att det faktiskt är någon som premunerar på eventet
    //    {
    //        PressLeft();
    //    }

    //    else if (PressRight != null && button == Button.right) //Kollar att det faktiskt är någon som premunerar på eventet
    //    {
    //        PressRight();
    //    }

    //}

    //Initierar en ButtonInput
    //public Button button;

    //För att att skicka ut ett event måste vi skapa en delegate
    public delegate void ButtonPress();
    

    //Här skapas sjäklva eventsen som kan hända
    public static ButtonPress PressLeft;
    public static ButtonPress PressRight;

#if (UNITY_EDITOR)
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            {
                if (PressLeft != null && hit.collider != null && hit.collider.tag == "Left")
                {
                    PressLeft();
                }

                else if (PressRight != null && hit.collider != null && hit.collider.tag == "Right")
                {
                    PressRight();
                }
            }
        }
    }

#elif (UNITY_IOS || UNITY_ANDROID)
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (PressLeft != null && hit.collider != null && hit.collider.tag == "Left")
                {
                    PressLeft();
                }
                else if (PressRight != null && hit.collider != null && hit.collider.tag == "Right")
                {
                    PressRight();
                }
            }

        }
    }


#endif
}
