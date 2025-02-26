using UnityEngine;

public class Overlapbox : MonoBehaviour
{
    [SerializeField] private LayerMask m_LayerMask;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MyCollisions();
    }
    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, transform.rotation, m_LayerMask);
        
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Debug.Log("Hit : " + hitColliders[i].name + i);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
