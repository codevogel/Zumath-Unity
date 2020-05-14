using Assets.Scripts;
using Controllers;
using References;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States.Game
{
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

        public static void SwitchToPreInsertion()
        {
            SetGameState(GameState.PREINSERTION);
        }

        public static void SwitchToPaused()
        {
            Pause();
        }

        public static void SwitchToBeforePaused()
        {
            Unpause();
        }

        public static void SwitchToResetting()
        {
            SetGameState(GameState.RESETTING);
        }

        public static void SwitchToWon()
        {
            ScoreAdd.AddEndLevelScore();
            SetGameState(GameState.WON);
        }

        public static void SwitchToCheckpoint()
        {
            prePauseGameState = currentGameState;
            SetGameState(GameState.CHECKPOINT);
            SceneManager.LoadScene(sceneName: "Checkpoint", LoadSceneMode.Additive);
        }
    }
}
