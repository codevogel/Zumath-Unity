﻿using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    class Tracer : MonoBehaviour
    {
        public LineRenderer directionLine;
        public Transform cannonTransform = null;
        public float mininumTracerLength = 50f;

        private const float lineWidth = 0.1f;

        public void Start()
        {
            directionLine.startWidth = lineWidth;
            directionLine.endWidth = lineWidth;
            directionLine.positionCount = 3;
        }

        private void Update()
        {
            Vector3 fakeMousePosition = Input.mousePosition;
            fakeMousePosition.z = 10; //stops the line from changing width
            Vector3 actualMousePosition = Camera.main.ScreenToWorldPoint(fakeMousePosition);
            Vector3 cannonPosition = cannonTransform.TransformPoint(Vector3.zero);
            Vector3 extendedLine = actualMousePosition;

            float x = actualMousePosition.x - cannonPosition.x;
            float y = actualMousePosition.y - cannonPosition.y;

            while (extendedLine.magnitude < mininumTracerLength) //causes the line to  extend while keeping the angle correct.
            {
                extendedLine.x += x;
                extendedLine.y += y;
            }
            
            directionLine.SetPosition(0, cannonPosition);
            directionLine.SetPosition(1, actualMousePosition);
            directionLine.SetPosition(2, extendedLine);


            GameState gameState = GameStateManager.GetGameState();
            if (gameState == GameState.CHECKPOINT || gameState == GameState.PAUSED || gameState == GameState.WON)
            {
                directionLine.enabled = false;
            }
            else
            {
                directionLine.enabled = true;
            }


        }

    }
}
