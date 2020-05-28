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
        public int OneStarThreshold, TwoStarThreshold, ThreeStarThreshold;
        public int EmittedStarParticles;
        public SpriteRenderer OneStar = null, TwoStar = null, ThreeStar = null;
        public ParticleSystem ps1 = null, ps2 = null, ps3 = null;
        public bool particle1Played, particle2Played, particle3Played;

        void Start()
        {
            OneStarThreshold = 1000;
            TwoStarThreshold = 2000;
            ThreeStarThreshold = 3000;

            EmittedStarParticles = 50;

            OneStar.enabled = false;
            TwoStar.enabled = false;
            ThreeStar.enabled = false;         
        }

        void Update()
        {
            if (ScoreAdd.score >= OneStarThreshold)
            {
                OneStar.enabled = true;
                if (!particle1Played)
                {
                    ps1.Emit(EmittedStarParticles);
                    particle1Played = true;
                }
            }
            if (ScoreAdd.score >= TwoStarThreshold)
            {
                TwoStar.enabled = true;
                if (!particle2Played)
                {
                    ps2.Emit(EmittedStarParticles);
                    particle2Played = true;
                }
            }

            if (ScoreAdd.score >= ThreeStarThreshold)
            {
                ThreeStar.enabled = true;
                if (!particle3Played)
                {
                    ps3.Emit(EmittedStarParticles);
                    particle3Played = true;
                }
            }
        }
    }
}
