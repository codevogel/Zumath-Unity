using Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DevTools
{
    class SpeedAdjuster : MonoBehaviour
    {
        public float disperseSpeed = 2f;
        public float travelSpeed = 0.5f;
        public float resetSpeed = 2.5f;

        private void Update()
        {
            NodeManager.SetTravelSpeed(travelSpeed);
            NodeManager.SetDisperseSpeed(disperseSpeed);
            NodeManager.SetResetSpeed(resetSpeed);
        }
    }
}
