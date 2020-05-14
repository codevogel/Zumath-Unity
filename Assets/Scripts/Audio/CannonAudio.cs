using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Audio
{
    class CannonAudio : AudioPlayer
    {
        private bool hasPlayed;

        private void Update()
        {
            if (GameStateManager.GetGameState() == GameState.SHOOTING && !hasPlayed)
            {
                play();
                hasPlayed = true;
            }
            if (GameStateManager.GetGameState() != GameState.SHOOTING)
            {
                hasPlayed = false;
            }
        }
    }
}
