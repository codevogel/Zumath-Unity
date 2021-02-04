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
        public float nodeZModifier =5;

        private void Update()
        {
            transform.position = getNodePosition();
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                EmitParticles(STANDARD_AMOUNT_OF_PARTICLES);
            }
        }

       // returns the position of node if node is not null. modifies the z so it is placed behind the node.
        private Vector3 getNodePosition()
        {
            if (node != null)
            {
                Vector3 vector = node.transform.position;
                vector.z += nodeZModifier;
                return vector;
            }
            else return transform.position;
            
        }

        public void setNode(NumberNode node)
        {
            this.node = node;
        }
    }
}