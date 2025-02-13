using System;
using UnityEditor;
using UnityEngine;

public class StaticCamera : MonoBehaviour
{
    public void CameraPOS()
    {
        Camera.main.transform.parent = transform; 
        Camera.main.transform.position = transform.position; //Sets a new position for the camera
        Camera.main.transform.rotation = transform.rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawSphere(transform.position, 0.5f);
        if (Selection.objects.Length == 0) { return; }
        if (Selection.objects[0] == transform.gameObject && Selection.objects.Length == 1)
        {
            Gizmos.DrawFrustum(transform.position, Camera.main.fieldOfView, Camera.main.farClipPlane, Camera.main.nearClipPlane, 1.777777f);
        }
        
        
    }
}
