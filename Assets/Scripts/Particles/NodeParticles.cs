using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    class NodeParticles : BaseParticles
    {
        private float timeStamp;
        private const float PARTICLE_COOLDOWN = 0.1f;


        //checks if more nodes should spawn particles if no particles have been spawned in the amount of time it takes for the particles to be spawned.
        private void Update()
        {
            if (timeStamp < Time.time)
            {
                if (ParticlesList.ShouldEmit(out Vector3 position))
                {
                    particle.transform.position = position;
                    EmitParticles();
                    timeStamp = Time.time + PARTICLE_COOLDOWN;
                }
            }
        }
    }
}
