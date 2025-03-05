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
        var var = FindAnyObjectByType<CharacterController>();
        var.GetComponent<Movement>().SetMovement(canmove);
        var.GetComponent<Movement>().SetCursor(canmovemouse);
        GetComponent<NpcDialogue>().ActivedUi();
    }
    
    public void LeaveInteract()
    {
        OnLeaveInteract.Invoke();
        if (GameObject.FindWithTag("Dia") && GameObject.FindWithTag("Dia").activeInHierarchy)
        {
            var var = FindAnyObjectByType<CharacterController>();
            var.GetComponent<Movement>().SetMovement(!canmove);
            var.GetComponent<Movement>().SetCursor(!canmovemouse);
            GetComponent<NpcDialogue>().DeactivedUi();
        } 
    }
}