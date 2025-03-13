using Unity.Burst.Intrinsics;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;

    [SerializeField] private GameObject backToMenuButton;

    private bool isopen;

    public UnityEvent paused = new();

    public UnityEvent resume = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resumeButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (GameObject.FindWithTag("Dia")) return;
        
        paused.Invoke();

        Time.timeScale = 0;
        
        if (isopen)
        {
            resumeGame();
        }
        else
        {
            isopen = true;
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        isopen = false;
        
        resume.Invoke();
    }

    public void backToMenu(string sceneName)
    {
        Time.timeScale = 1;
        isopen = false;
        
        SceneManager.LoadScene(sceneName);

    }
}
