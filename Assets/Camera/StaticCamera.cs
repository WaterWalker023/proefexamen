using UnityEngine;

public class StaticCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraPOS()
    {
        Camera.main.transform.parent = transform; 
        Camera.main.transform.position = transform.position; //Sets a new position for the camera
        Camera.main.transform.rotation = transform.rotation;
    }
}
