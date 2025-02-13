using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 lookDirection;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection.y = transform.position.y;
        transform.LookAt(lookDirection);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(lookDirection, 0.5f);
    }
}