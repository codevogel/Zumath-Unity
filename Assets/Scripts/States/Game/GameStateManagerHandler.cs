
using UnityEngine;

namespace States.Game
{
    class GameStateManagerHandler : MonoBehaviour
    {

        void Start()
        {
            GameStateManager.Start();
        }

        void Update()
        {
            GameStateManager.Update();
        }
    }
}


