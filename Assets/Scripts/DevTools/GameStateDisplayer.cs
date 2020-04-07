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
                case GameState.SPAWNING:
                    currentGameState = "Spawning";
                    return;
                case GameState.PREINSERTION:
                    currentGameState = "Pre-insertion";
                    return;
                case GameState.DISPERSING:
                    currentGameState = "Dispersing";
                    return;
                case GameState.RESETTING:
                    currentGameState = "Resetting";
                    return;
                case GameState.PAUSED:
                    currentGameState = "Paused";
                    return;
            }
        }
    }
}
