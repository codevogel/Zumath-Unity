using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    //stores the locations particles should spawn
    public static class ParticlesList
    {

        private static List<Vector3> positions = new List<Vector3>();

        //adds 1 or more positions to the particle list
        public static void Add(params Vector3[] positions)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                ParticlesList.positions.Add(positions[i]);
            }

        }

        //returns true if there is a location that should have particles and outputs that location as param. Also removes that Vector3 from the list.
        public static bool ShouldEmit(out Vector3 position)
        {
            if (positions.Count() > 0)
            {
                position = positions.ElementAt(0);
                positions.Remove(position);
                return true;
            }
            else
                position = new Vector3();
                return false;
        }


    }
}
