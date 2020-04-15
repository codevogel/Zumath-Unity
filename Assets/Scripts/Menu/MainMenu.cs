using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(0); 
    }
    public void ExitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
