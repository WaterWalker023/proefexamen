using System.Collections.Generic;
using UnityEngine;

public class Overlapbox : MonoBehaviour
{
    [SerializeField] private LayerMask m_LayerMask;
    private Collider[] ListColliders;

    void Start()
    {
    }

    void FixedUpdate()
    {
        MyCollisions();
        if (Input.GetKeyUp(KeyCode.E))
        {
            Interact();
        }
    }

    void MyCollisions()
    {
        ListColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2,
            transform.rotation, m_LayerMask);
    }

    public void Interact()
    {
        for (int i = 0; i < ListColliders.Length; i++)
        {
            if (ListColliders[i].GetComponent<Interact>())
            {
                ListColliders[i].GetComponent<Interact>().Interacting();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}