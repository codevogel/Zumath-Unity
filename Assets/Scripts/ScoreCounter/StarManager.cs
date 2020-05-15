using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScoreCounter
{
    class StarManager : MonoBehaviour
    {
        void Start()
        {
            Star.Start();            
        }

        void Update()
        {
            if (ScoreAdd.score >= 1000 && ScoreAdd.score < 2000)
            {
                starOne.enabled = true;
                oneStarEnabled = true;
            }
            else if (ScoreAdd.score >= 2000 && ScoreAdd.score < 3000)
            {
                starTwo.enabled = true;
                twoStarEnabled = true;
            }

            else if (ScoreAdd.score >= 3000)
            {
                starThree.enabled = true;
                threeStarEnabled = true;
            }
        }


    }

}
