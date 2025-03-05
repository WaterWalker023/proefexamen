using UnityEngine;

public class TestMove : MonoBehaviour
{
    public Transform target;
    private float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
