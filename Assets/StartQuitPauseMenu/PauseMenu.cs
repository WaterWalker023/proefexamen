using Unity.Burst.Intrinsics;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;

    [SerializeField] private GameObject backToMenuButton;
    
    [SerializeField] private TMP_Text titleText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resumeButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            resumeButton.SetActive(true);
            backToMenuButton.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        
        resumeButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    public void backToMenu(string sceneName)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(sceneName);

    }
}
