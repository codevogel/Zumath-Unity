using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    class CannonParticles : BaseParticles
    {

        private void Update()
        {
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                if (!hasEmitted)
                {
                    EmitParticles();
                }
            }
            else
            {
                hasEmitted = false;
            }
            
        }
    }
}
