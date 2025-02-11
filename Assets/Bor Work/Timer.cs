using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Timer: MonoBehaviour
{
    public int time;
    public int seconds = 1;
    
    
    
    public void Start()
    {
        Debug.Log("Start Time");
    }

    public void Update()
    {
        for (time = 10; time > 0; --seconds)
        {
            
        }
    }
}
