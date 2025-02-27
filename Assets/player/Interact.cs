using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public UnityEvent OnInteract = new UnityEvent();

    public void Interacting()
    {
        Debug.Log("Interacting");
    }
}