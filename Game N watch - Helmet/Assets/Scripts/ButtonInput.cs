using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    //Skapar en "lista" på vad som kan hända.
    public enum Button
    {
        left,
        right
    }


    //Initierar en ButtonInput
    public Button button;

    //För att att skicka ut ett event måste vi skapa en delegate
    public delegate void ButtonPress();
    

    //Här skapas sjäklva eventsen som kan hända
    public static ButtonPress PressLeft;
    public static ButtonPress PressRight;

        private void OnMousDown()
        {
            
            if (PressLeft != null && button == Button.left) //Kollar att det faktiskt är någon som premunerar på eventet
            {
                PressLeft();
            }

            else if (PressRight != null && button == Button.right) //Kollar att det faktiskt är någon som premunerar på eventet
            {
                PressRight();
            }

        }
    
}
