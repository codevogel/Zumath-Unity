using Controllers;
using Nodes;
using References;
using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GameStateManagerHandler : MonoBehaviour
    {
        private NodeSpawner nodeSpawner;
        private static CanonController canonController;

        private void Awake()
        {
            GameStateManager.Init();
            NodeManager.Init();
        }


    }
}
