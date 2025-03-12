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
        if (!Input.GetKey(KeyCode.Escape)) return;
        if (!GameObject.FindWithTag("Dia"))
        {
            paused.Invoke();

            Time.timeScale = 0;
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        
        resume.Invoke();
    }

    public void backToMenu(string sceneName)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(sceneName);

    }
}
