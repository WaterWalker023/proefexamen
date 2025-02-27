using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed = 12f;
    [SerializeField] float gravity = -10;
    [SerializeField] private float sensitivity;

    private Vector3 Velocity;
    private float x;
    private float z;
    private float mouseX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        
        Velocity.y = -2;
        Velocity.y += gravity * Time.deltaTime;
        characterController.Move(Velocity * Time.deltaTime);
        
        var move = transform.right * x + transform.forward * z;
        characterController.Move(move * (speed * Time.deltaTime));
    }
}
