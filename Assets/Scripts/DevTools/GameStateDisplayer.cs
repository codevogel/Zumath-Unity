using States.Game;
using System;
using UnityEngine;

namespace DevTools
{
    class GameStateDisplayer : MonoBehaviour
    {

        public string currentGameState;

        void Update()
        {
            switch (GameStateManager.GetGameState())
            {
                case GameState.PREINSERTION:
                    currentGameState = "Pre-insertion";
                    return;
                case GameState.SHOOTING:
                    currentGameState = "Shooting";
                    return;
                case GameState.DISPERSING:
                    currentGameState = "Dispersing";
                    return;
                case GameState.MOVEBACK:
                    currentGameState = "Move back";
                    return;
                case GameState.RESETTING:
                    currentGameState = "Resetting";
                    return;
                case GameState.PAUSED:
                    currentGameState = "Paused";
                    return;
                case GameState.CHECKPOINT:
                    currentGameState = "Checkpoint";
                    return;
                case GameState.WON:
                    currentGameState = "Won";
                    return;
                case GameState.GAMEOVER:
                    currentGameState = "Gameover";
                    return;
                default:
                    currentGameState = "Unknown";
                    return;
            }
        }
    }
}
