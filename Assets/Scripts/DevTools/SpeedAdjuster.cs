using Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DevTools
{
    // Used to adjust the diverse travel speeds on runtime in the inspector view
    class SpeedAdjuster : MonoBehaviour
    {
        
        public float travelSpeed = 0.5f;
        public float disperseSpeed = 2f;
        public float movebackSpeed = 2f;
        public float resetSpeed = 2.5f;

        private void Update()
        {
            NodeManager.SetTravelSpeed(travelSpeed);
            NodeManager.SetDisperseSpeed(disperseSpeed);
            NodeManager.SetMoveBackSpeed(movebackSpeed);
            NodeManager.SetResetSpeed(resetSpeed);
        }
    }
}
