using Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DevTools
{
    class MoveBackAdjuster : MonoBehaviour
    {
        // Amount of seconds the balls will move back on damage.
        public float moveBackLenght = 1;

        private void Start()
        {
            NodeManager.SetMoveBackLenght(moveBackLenght);
            NodeManager.UpdateMoveBackLenght();
        }

        private void Update()
        {
            NodeManager.SetMoveBackLenght(moveBackLenght);
        }
    }
}