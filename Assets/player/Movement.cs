using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed = 12f;
    [SerializeField] float gravity = -10;

    private Vector3 Velocity;
    private float x;
    private float z;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Velocity.y = -2;
        Velocity.y += gravity * Time.deltaTime;
        characterController.Move(Velocity * Time.deltaTime);
        
        var move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
