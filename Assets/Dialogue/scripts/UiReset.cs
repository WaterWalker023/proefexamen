using UnityEngine;

public class UiReset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.FindWithTag("NPC").GetComponent<Interact>().LeaveInteract();
        }
    }
}
