using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    private void Start()
    {
        LoadMainMenu();
    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
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
