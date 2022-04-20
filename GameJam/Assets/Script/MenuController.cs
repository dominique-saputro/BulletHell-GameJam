using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]

    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LevelSelectDialog_Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelSelectDialog_Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelSelectDialog_Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
