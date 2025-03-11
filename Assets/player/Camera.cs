using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float sensY;

    public Transform maincameraofplayer;

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

        Debug.Log(YRotation);
        
        YRotation = Mathf.Clamp(YRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(YRotation, transform.rotation.eulerAngles.y, 0);
    }
}
