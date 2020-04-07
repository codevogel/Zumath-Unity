
using UnityEngine;

namespace States.Game
{
    class GameStateManagerHandler : MonoBehaviour
    {

        private void Awake()
        {
            GameStateManager.Awake();
        }

        void Update()
        {
            GameStateManager.Update();
        }
    }
}


