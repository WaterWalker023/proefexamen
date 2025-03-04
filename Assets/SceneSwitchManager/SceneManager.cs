using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
