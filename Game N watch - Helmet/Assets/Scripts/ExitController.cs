﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    // Start is called before the first frame update
  private void OnMouseDown()
    {
        Application.Quit();
    }
}
