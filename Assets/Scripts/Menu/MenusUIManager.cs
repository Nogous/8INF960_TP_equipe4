using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class MenusUIManager : MonoBehaviour
{
    [SerializeField]
    private string mainMenuSceneName;
    [SerializeField]
    private string creditsMenuSceneName;

    public void LoadCreditsMenu()
    {
        SceneManager.LoadScene(creditsMenuSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void LoadGame(int index=2)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadGame(string name)
    {
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
