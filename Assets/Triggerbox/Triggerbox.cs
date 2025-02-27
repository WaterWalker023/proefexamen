using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Triggerbox : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;
    public UnityEvent OnPlayerStay;
    public UnityEvent OnPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<CharacterController>())
        {
            OnPlayerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.GetComponent<CharacterController>())
        {
            OnPlayerStay.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<CharacterController>())
        {
            OnPlayerExit.Invoke();
        }
    }


    void OnDrawGizmos()
    {
        var box = GetComponent<BoxCollider>();
        Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.2f);
        Gizmos.DrawCube(transform.position,
            new Vector3(transform.localScale.x * box.size.x, transform.localScale.y * box.size.y,
                transform.localScale.z * box.size.z));


        Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        Gizmos.DrawWireCube(transform.position,
            new Vector3(transform.localScale.x * box.size.x, transform.localScale.y * box.size.y,
                transform.localScale.z * box.size.z));
    }
}