using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Assets.Scripts.ScoreCounter
{
    class StarManager : MonoBehaviour
    {
        public ParticleSystem ps1, ps2, ps3;
        public Image OneStar, TwoStar, ThreeStar;
        public bool particle1Played, particle2Played, particle3Played;

        void Start()
        {
            OneStar.enabled = false;
            TwoStar.enabled = false;
            ThreeStar.enabled = false;
        }

        void Update()
        { 
            if (ScoreAdd.score >= 50)
            {
                OneStar.enabled = true;

                if (!particle1Played)
                {
                    ps1.Emit(50);
                    particle1Played = true;
                }
            }

            if (ScoreAdd.score >= 100)
            {
                TwoStar.enabled = true;

                if (!particle2Played)
                {
                    ps2.Emit(50);
                    particle2Played = true;
                }
            }

            if (ScoreAdd.score >= 200)
            {
                ThreeStar.enabled = true;

                if (!particle3Played)
                {
                    ps3.Emit(50);
                    particle3Played = true;
                }
            }
        }
    }
}
