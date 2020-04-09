
using States.Game;
using UnityEngine;

namespace Controllers
{
    class GameStateManagerController : MonoBehaviour
    {
        void Update()
        {
            if (GameStateManager.GetGameState() == GameState.PAUSED)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    GameStateManager.Unpause();
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameStateManager.Pause();
            }
        }
    }
}


