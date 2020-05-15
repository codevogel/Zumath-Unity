using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Particles
{
    class NodePartciles : BaseParticles
    {

        public new void EmitParticles()
        {
            particle.Emit(EMIT);
        }
    }
}