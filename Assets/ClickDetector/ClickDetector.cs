using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ClickDetector : MonoBehaviour
{
    public UnityEvent chosenNPC = new();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void barrierClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("You have chosen me!");
            chosenNPC.Invoke();
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (transform.forward * 3) + transform.position);
        Gizmos.DrawSphere(transform.position, 0.5f);
        //Gizmos.
    }
}
