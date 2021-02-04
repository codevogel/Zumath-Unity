using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Audio
{
    public class AudioPlayer : BaseAudioPlayer
    {
        private bool shouldPlay;

        public bool ShouldPlay { get => shouldPlay; set => shouldPlay = value; }

        private void Update()
        {
            if (shouldPlay && !hasPlayed)
            {
                play();
                hasPlayed = true;
                shouldPlay = false;
            }
            if (!shouldPlay)
            {
                hasPlayed = false;
            }
        }

    }
}
