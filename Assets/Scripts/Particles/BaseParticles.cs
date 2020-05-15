using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public abstract class BaseParticles : MonoBehaviour
    {
        public ParticleSystem particle;
        protected bool hasEmitted;
        protected const int STANDARD_AMOUNT_OF_PARTICLES = 50;

        //Causes the connected particle sytem to emit particles stops particles from constantly spawning.
        protected void EmitParticles(int amountOfParticles = STANDARD_AMOUNT_OF_PARTICLES)
        {
            hasEmitted = true;
            particle.Emit(amountOfParticles);
        }
    }
}
