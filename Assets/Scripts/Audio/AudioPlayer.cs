using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    class AudioPlayer : MonoBehaviour
    {
        public AudioSource audio;
        

        public void play()
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        
    }
}
