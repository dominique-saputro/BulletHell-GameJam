using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Dialog Popouts")]
    public GameObject dialogGameOver;
    public GameObject dialogNextLevel;

    [Header("Player and Target Object")]
    public Target currentTarget;
    public Player player;
    public AudioSource music;

    private void Update() 
    {
        if(currentTarget.isEnemyDead)
        {
            showNextLevelDialog();
            music.Pause();
        }

        if(!player.isAlive)
        {
            showGameOverDialog();
            music.Pause();
        }    
    }

    public void showGameOverDialog()
    {
        dialogGameOver.SetActive(true);
    }

    public void showNextLevelDialog()
    {
        dialogNextLevel.SetActive(true);
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void nextLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void nextLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}
