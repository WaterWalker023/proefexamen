using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 lookDirection;


    void Update()
    {
        lookDirection.y = transform.position.y;
        transform.LookAt(lookDirection);
    }

    void OnDrawGizmos()
    {
        if (Selection.objects[0] == transform.gameObject)
        {
            Gizmos.color = new Color(0, 1, 1, 0.5f);
            Gizmos.DrawSphere(lookDirection, 0.5f);
        }
    }


}