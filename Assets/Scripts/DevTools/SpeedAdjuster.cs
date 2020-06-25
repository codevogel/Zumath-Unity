using Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using References;
using PowerUps;

namespace Assets.Scripts.DevTools
{
    // Used to adjust the diverse travel speeds on runtime in the inspector view
    class SpeedAdjuster : MonoBehaviour
    {
        public float powerUpTimeSlowAmount = 2f;
        public float travelSpeed = 0.5f;
        public float disperseSpeed = 2f;
        public float movebackSpeed = 2f;
        public float resetSpeed = 2.5f;

        public float GetTravelSpeed()
        {
            if (PowerUpManager.triggerPowerUp)
            {
                return travelSpeed / powerUpTimeSlowAmount;
            }
            else
            {
                return travelSpeed;
            }
        }

        private void Update()
        {
            NodeManager.SetTravelSpeed(GetTravelSpeed());
            NodeManager.SetDisperseSpeed(disperseSpeed);
            NodeManager.SetMoveBackSpeed(movebackSpeed);
            NodeManager.SetResetSpeed(resetSpeed);
        }
    }
}
