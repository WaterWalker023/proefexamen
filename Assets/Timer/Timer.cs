using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Timer: MonoBehaviour
{
    [SerializeField] private float timeleft = 10;

    [SerializeField] private TMP_Text timerText;
    
    public UnityEvent timeOn0 = new();

    public void Update()
    {
        if (timeleft == 0) return;
        timeleft = timeleft - Time.deltaTime;
        timerText.text = "Timer: " + (int) timeleft;

        if (timeleft <= 0)
        {
            timeleft = 0;
            timeOn0.Invoke();
            
        }
    }
}
