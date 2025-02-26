using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float angle;

    private float x;

    private float z;

    private GameObject RotatorObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RotatorObject = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        /*
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        if (new Vector2(x, z) == Vector2.zero) return;

        angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        RotatorObject.transform.rotation = Quaternion.Euler(0, angle + transform.parent.rotation.y, 0);
*/

        //RotatorObject.transform.rotation += transform.parent.rotation;
    }
}