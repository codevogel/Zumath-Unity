using Assets.Scripts;
using Controllers;
using References;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States.Game
{
    // Handles switching of gamestates. 
    // Loads the required scenes if these states take place in a different scene.
    // Each gamestate has it's own SwitchTo method, making it easier to find
    // where each gamestate is used by looking at the method's references.
    public static class GameStateManager
    {
        private static GameState currentGameState;
        private static GameState prePauseGameState;

        public static void Init()
        {
            SwitchToPreInsertion();
        }

        public static void Pause()
        {
            if (currentGameState == GameState.PAUSED)
            {
                return;
            }
            prePauseGameState = currentGameState;
            currentGameState = GameState.PAUSED;
            SceneManager.LoadScene(sceneName: "PauseScreen", LoadSceneMode.Additive);
        }

        public static void Unpause()
        {
            currentGameState = prePauseGameState;
        }

        public static GameState GetGameState()
        {
            return currentGameState;
        }

        private static void SetGameState(GameState gameState)
        {
            currentGameState = gameState;
        }

        public static void SwitchToShooting()
        {
            SetGameState(GameState.SHOOTING);
        }

        public static void SwitchToDispersing()
        {
            SetGameState(GameState.DISPERSING);
        }

        public static void SwitchToMoveBack()
        {
            SetGameState(GameState.MOVEBACK);
        }

        public static void SwitchToPreInsertion()
        {
            SetGameState(GameState.PREINSERTION);
        }

        public static void SwitchToGameover()
        {
            ScoreAdd.GameOverScore();
            SceneManager.LoadScene("LossScreen");
            SetGameState(GameState.GAMEOVER);
        }

        public static void SwitchToResetting()
        {
            SetGameState(GameState.RESETTING);
        }

        public static void SwitchToWon()
        {
            ScoreAdd.AddEndLevelScore();
            SceneManager.LoadScene("WinScreen");
        }

        public static void SwitchToCheckpoint()
        {
            prePauseGameState = currentGameState;
            SetGameState(GameState.CHECKPOINT);
            SceneManager.LoadScene(sceneName: "Checkpoint", LoadSceneMode.Additive);
        }
    }
}
