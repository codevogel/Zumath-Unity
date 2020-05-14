using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PauseScreen
{
    class PauseScreen : MonoBehaviour
    {
        public void ResumeButtonPressed()
        {
            SceneManager.UnloadScene(sceneName: "PauseScreen");
            GameStateManager.Unpause();
        }

        public void SettingsButtonPressed()
        {
            print("ToDo Settings");
        }

        //copied from MainMenu
        public void ExitButtonPressed()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
