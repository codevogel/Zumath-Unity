using Nodes;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using References;

namespace Assets.Scripts.DevTools
{
    class HealthAdjuster : MonoBehaviour
    {
        public float totalHealth = 3f;
        public float damagePerNode = 1;

        private void Awake()
        {
            gameObject.tag = Tags.HEALTH;
        }

        public void UpdateHealth()
        {
            totalHealth -= damagePerNode;
        }

        private void Update()
        {
            HealthController.SetAmountOfHealth(totalHealth);
            HealthController.SetDamagePerDestroyedNode(damagePerNode);
        }
    }
}
