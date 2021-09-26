using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class MenusUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuScene;
    [SerializeField]
    private GameObject creditsMenuScene;

    [SerializeField]
    private RectTransform background;

    private Vector3 tmpPos;
    private float focusPos = 650f;
    private float posBGMain;

    public float speed = 1f;

    private void Start()
    {
        mainMenuScene.SetActive(true);
        creditsMenuScene.SetActive(false);
        posBGMain = focusPos = background.position.x;
    }

    public void LoadCreditsMenu()
    {
        mainMenuScene.SetActive(false);
        focusPos = 78f;
    }

    public void LoadMainMenu()
    {
        creditsMenuScene.SetActive(false);
        focusPos = posBGMain;
    }

    public void LoadGame()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        if (background.position.x == focusPos) return;

        tmpPos = background.position;
        if (tmpPos.x<focusPos)
        {
            tmpPos.x += Time.deltaTime * speed;
            if (tmpPos.x>focusPos)
            {
                tmpPos.x = focusPos;
                mainMenuScene.SetActive(true);
            }
        }
        else
        {
            tmpPos.x -= Time.deltaTime * speed;
            if (tmpPos.x < focusPos)
            {
                tmpPos.x = focusPos;
                creditsMenuScene.SetActive(true);
            }
        }
        background.position = tmpPos;
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
