using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;
    
    [SerializeField] private Transform gameplayCameraPos;
    
    [SerializeField] private bool hasClicked = false;

    [SerializeField] private TMP_Text titleText;

    private void Update()
    {
        if (hasClicked)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, gameplayCameraPos.position, 10 * Time.deltaTime);
            Debug.Log("Camera moving");
        }
    }

    public void GameBegin()
    {
        hasClicked = true;
        
        startButton.SetActive(false);
        quitButton.SetActive(false);
        titleText.gameObject.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
}
