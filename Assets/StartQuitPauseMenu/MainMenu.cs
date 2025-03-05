using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject startButton;
    public GameObject quitButton;
    
    public Transform gameplayCameraPos;
    
    private bool hasClicked = false;

    public TMP_Text titleText;

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
