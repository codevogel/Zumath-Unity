using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class PausedNoDisplay : MonoBehaviour
    {
        public LineRenderer line = null;

        private void Update()
        {
            if (GameStateManager.GetGameState() == GameState.PAUSED)
            {
                line.enabled = false;
            } else
                line.enabled = true;
        }

    }
}
