using Nodes;
using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class NodeInTransitParticles : BaseParticles
    {
        private NumberNode node;
        private const int STANDARD_AMOUNT_OF_PARTICLES = 1;

        private void Update()
        {
            transform.position = getNodePosition();
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                EmitParticles(STANDARD_AMOUNT_OF_PARTICLES);
            }
        }

       // returns the position of node if node is not null.
        private Vector3 getNodePosition()
        {
            return node != null ? node.transform.position : transform.position;
        }

        public void setNode(NumberNode node)
        {
            this.node = node;
        }
    }
}