using Assets.Scripts.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ScoreCounter
{
    class StarManager : MonoBehaviour
    {
        public SpriteRenderer OneStar = null, TwoStar = null, ThreeStar = null;
        public ParticleSystem ps1 = null, ps2 = null, ps3 = null;
        public AudioPlayer audioPlayer=null;
        public bool particle1Played, particle2Played, particle3Played;

        void Start()
        {
            OneStar.enabled = false;
            TwoStar.enabled = false;
            ThreeStar.enabled = false;         
        }

        void Update()
        {
            if (ScoreAdd.score >= 1000)
            {
                OneStar.enabled = true;
                audioPlayer.ShouldPlay = false;
                if (!particle1Played)
                {
                    audioPlayer.ShouldPlay = true;
                    ps1.Emit(50);
                    particle1Played = true;
                }
            }
            if (ScoreAdd.score >= 2000)
            {
                TwoStar.enabled = true;
                if (!particle2Played)
                {
                    audioPlayer.ShouldPlay = true;
                    ps2.Emit(50);
                    particle2Played = true;
                }
            }

            if (ScoreAdd.score >= 3000)
            {
                ThreeStar.enabled = true;
                if (!particle3Played)
                {
                    audioPlayer.ShouldPlay = true;
                    ps3.Emit(50);
                    particle3Played = true;
                }
            }
        }
    }
}
