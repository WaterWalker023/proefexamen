using UnityEngine;

public class diaToggle : MonoBehaviour
{
    [SerializeField] private GameObject diaNpc;
    [SerializeField] private GameObject diaInput;
    void Start()
    {
        
    }

    private void Toggle()
    {
        diaNpc.SetActive (!diaNpc.activeInHierarchy);
        diaInput.SetActive (!diaInput.activeInHierarchy);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
