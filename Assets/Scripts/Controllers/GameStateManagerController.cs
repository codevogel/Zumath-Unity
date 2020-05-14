
using States.Game;
using UnityEngine;

namespace Controllers
{
    class GameStateManagerController : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameStateManager.Pause();
            }
        }
    }
}


