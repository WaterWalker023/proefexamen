using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    
    [SerializeField] private Transform gameplayCameraPos;
    
    [SerializeField] private bool hasClicked = false;

    public UnityEvent hasclickt = new();
    public UnityEvent _camerathere = new();
    
    private void Update()
    {
        if (!hasClicked) { return; }

        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, gameplayCameraPos.position, 25 * Time.deltaTime);
        if (mainCamera.transform.position == gameplayCameraPos.position)
        {
            _camerathere.Invoke();
            enabled = false;
        }
        
    }

    public void GameBegin()
    {
        hasClicked = true;
        
        hasclickt.Invoke();
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
}
