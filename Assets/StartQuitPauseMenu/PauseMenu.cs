using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject resumeButton;

    public GameObject quitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            resumeButton.SetActive(true);
            quitButton.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }
}
