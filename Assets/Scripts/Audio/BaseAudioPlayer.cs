using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public abstract class BaseAudioPlayer : MonoBehaviour
    {
        public new AudioSource audio;
        protected bool hasPlayed;


        public void play()
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        
    }
}
