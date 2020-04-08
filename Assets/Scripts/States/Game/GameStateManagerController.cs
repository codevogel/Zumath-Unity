
using UnityEngine;

namespace States.Game
{
    class GameStateManagerController : MonoBehaviour
    {
        void Update()
        {
            if (GameStateManager.GetGameState() == GameState.PAUSED)
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    GameStateManager.Unpause();
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                GameStateManager.Pause();
            }
        }
    }
}


