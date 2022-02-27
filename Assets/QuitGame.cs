using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Quit",20);
    }

    private void Quit()
    {
        Application.Quit();
    }
}