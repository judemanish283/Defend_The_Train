using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class NewCoordinateLabel : MonoBehaviour
{
    TextMeshPro label;

    private void Awake()
    {
       label = GetComponent<TextMeshPro>();

    }
    
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
        }
    }

    void DisplayCoordinates()
    {
        label.text = "----,---";
    }
}
