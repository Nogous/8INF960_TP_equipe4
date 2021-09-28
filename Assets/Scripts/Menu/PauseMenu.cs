using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private string creditsMenuSceneName;

    public void LoadCreditsMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(creditsMenuSceneName);
    }

    public void LoadGame(int index=2)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
    public void LoadGame(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }


    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
