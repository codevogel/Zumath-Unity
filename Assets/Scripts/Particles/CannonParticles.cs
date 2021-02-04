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
        public Transform cannonTransform=null;

        private void Start()
        {
            transform.position = cannonTransform.position;
        }


        private void Update()
        {
            //This only happends when a ball is shot
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                if (!hasEmitted)
                {
                    EmitParticles();
                }
            }
            else
            {
                //resets the hasEmmited for the next time the cannon fires.
                hasEmitted = false;
            }
            
        }
    }
}
