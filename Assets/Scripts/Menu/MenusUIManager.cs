using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class MenusUIManager : MonoBehaviour
{
    [SerializeField]
    private string mainMenuSceneName = "MainMenu";
    [SerializeField]
    public string creditsMenuSceneName = "CreditsMenu";

    public void LoadCreditsMenu()
    {
        SceneManager.LoadScene(creditsMenuSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void LoadGame()
    {
        throw new NotImplementedException();
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
