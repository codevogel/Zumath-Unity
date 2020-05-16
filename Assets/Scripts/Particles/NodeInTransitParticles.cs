using Nodes;
using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Particles
{
    public class NodeInTransitParticles : BaseParticles
    {
        private NumberNode node;
        private const int STANDARD_AMOUNT_OF_PARTICLES = 1;

        private void Update()
        {
            if (node != null)
            {
                transform.position = node.transform.position;
            }
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                    EmitParticles(STANDARD_AMOUNT_OF_PARTICLES);
            }
        }

        public void setNode(NumberNode node)
        {
            this.node = node;
        }
    }
}