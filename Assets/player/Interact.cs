using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    [SerializeField] private bool canmovemouse;
    [SerializeField] private bool canmove;
    public UnityEvent OnInteract = new UnityEvent();
    public UnityEvent OnLeaveInteract = new UnityEvent();

    public void Interacting()
    {
        OnInteract.Invoke();
        GetComponent<Movement>().SetMovement(canmove);
        GetComponent<Movement>().SetCursor(canmovemouse);
        GetComponent<NpcDialogue>().Toggle();
    }
    
    public void LeaveInteract()
    {
        Debug.Log("Left Interacting");  
    }
}