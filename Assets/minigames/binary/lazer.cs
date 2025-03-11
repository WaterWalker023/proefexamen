using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class lazer : MonoBehaviour
{
    
    [SerializeField] private GameObject lazerobject;
    void Update()
    {
        lazerobject.transform.position = transform.position;
        
        Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, Mathf.Infinity);
        //lazerobject.transform.position = hit.point;
        
        Vector3 reflectedVelocity = Vector3.Reflect(transform.forward, hit.normal);
        
        Physics.Raycast(hit.point, reflectedVelocity, out RaycastHit hit2, Mathf.Infinity);
        //lazerobject.transform.position = hit2.point;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, Mathf.Infinity);
        Gizmos.DrawRay(transform.position, Vector3.forward * hit.distance);
        
        Vector3 reflectedVelocity = Vector3.Reflect(transform.forward, hit.normal);
        //Debug.Log(hit.normal);
        
        //Debug.Log("Reflected Velocity: " + reflectedVelocity);
        
        Physics.Raycast(hit.point, reflectedVelocity, out RaycastHit hit2, Mathf.Infinity);
        //Debug.Log(hit2.point);
        Gizmos.DrawRay(hit.point, reflectedVelocity * hit2.distance);
    }
}   
