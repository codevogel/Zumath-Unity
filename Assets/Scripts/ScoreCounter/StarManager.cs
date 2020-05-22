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
        public Image OneStar, TwoStar, ThreeStar;

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
            }

            if (ScoreAdd.score >= 100)
            {
                TwoStar.enabled = true;
            }

            if (ScoreAdd.score >= 200)
            {
                ThreeStar.enabled = true;
            }
        }
    }
}
