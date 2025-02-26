using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{
    public UnityEvent chosenNPC = new();
    [SerializeField] private GameObject sphere;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        //mousePos.z = 1f;
        //Debug.Log( Camera.main.ScreenToWorldPoint(mousePos));
        //Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), transform.forward, out RaycastHit hit, Mathf.Infinity);

        Ray hit = Camera.main.ScreenPointToRay(mousePos);
        
        RaycastHit hitInfo;
        
        //if (Physics.Raycast(hit, out hitInfo))
        //sphere.transform.position = hitInfo.point;
        
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(hit, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
        }
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
