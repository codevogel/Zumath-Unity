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
            GameStateManager.Unpause();
            SceneManager.UnloadSceneAsync(sceneName: "PauseScreen");
        }

        //copied from MainMenu
        public void ExitButtonPressed()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
