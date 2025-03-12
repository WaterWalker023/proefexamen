using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiReset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindWithTag("NPC").GetComponent<Interact>().LeaveInteract();
        }
    }
}
