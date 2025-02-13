using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;

public class Timer: MonoBehaviour
{
    public float time = 10;

    [SerializeField]
    public TMP_Text timerText;
    
    public UnityEvent timeOn0 = new();
    
    public void Start()
    {
        Debug.Log("Start Time");
    }

    public void Update()
    {
        if (time == 0) return;
        time = time - Time.deltaTime;
        timerText.text = "Timer: " + (int) time;

        if (time <= 0)
        {
            time = 0;
            timeOn0.Invoke();
            
        }
    }
}
