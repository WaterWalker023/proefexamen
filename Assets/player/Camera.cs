using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float sensY;

    private float YRotation;
    
    private float mouseY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        YRotation -= mouseY;

        
        YRotation = Mathf.Clamp(YRotation, -10f, 60f);
        transform.rotation = Quaternion.Euler(YRotation, transform.rotation.eulerAngles.y, 0);
    }
}
