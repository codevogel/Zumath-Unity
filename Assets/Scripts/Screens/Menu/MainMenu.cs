using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject
        tutorialText = null,
        zumath = null,
        exitButton = null,
        playButton = null,
        tutorialButton = null;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "MainScene");
    }

    public void DisplayTutorial()
    {
        tutorialText.SetActive(true);
        zumath.SetActive(false);
        exitButton.SetActive(false);
        playButton.SetActive(false);
        tutorialButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NoDisplayTutorial();
        }
    }


    public void NoDisplayTutorial()
    {
        tutorialText.SetActive(false);
        zumath.SetActive(true);
        exitButton.SetActive(true);
        playButton.SetActive(true);
        tutorialButton.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
