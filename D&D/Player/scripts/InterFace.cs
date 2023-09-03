using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterFace : MonoBehaviour
{
    public int sceneint = 1;
    public GameObject PauseMenu;
    public GameObject InGameUI;

    public bool gameIsPaused;
    public Text gameComplited;
    private void Start()
    {
        // AL = GetComponentInChildren<AudioListener>();
        gameComplited.text = "Game complited: " + PlayerPrefs.GetInt("SavedInteger").ToString();
        gameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();

        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            AudioListener.pause = true;
            Time.timeScale = 0f;
            InGameUI.SetActive(false);
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            AudioListener.pause = false;
            Time.timeScale = 1;
            InGameUI.SetActive(true);
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(sceneint);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}