using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using References;
using States.Game;
using Nodes;
using Assets.Scripts.DevTools;
using Assets.Scripts.Audio;

namespace Controllers
{
    public class HealthController : MonoBehaviour
    {
        private static float AMOUNT_OF_HEALTH = 3f;
        private static float DAMAGE_PER_DESTROYED_NODE = 1f;

        private HealthAdjuster healthAdjuster;
        public AudioPlayer damageAudio,deathAudio;

        private void Awake()
        {
            gameObject.tag = Tags.HEALTH;
            healthAdjuster = GameObject.FindGameObjectWithTag(Tags.HEALTH).GetComponent<HealthAdjuster>();
        }

        public static void SetAmountOfHealth(float health)
        {
            AMOUNT_OF_HEALTH = health;
        }

        public static void SetDamagePerDestroyedNode(float damage)
        {
            DAMAGE_PER_DESTROYED_NODE = damage;
        }
        
        // Is used to say what happens when you take damage.
        public void RemoveLife()
        {
            AMOUNT_OF_HEALTH -= DAMAGE_PER_DESTROYED_NODE;
            healthAdjuster.UpdateHealth();

            if (AMOUNT_OF_HEALTH <= 0)
            {
                GameStateManager.SwitchToGameover();
                return;
            }
            damageAudio.ShouldPlay = true;
        }

        public static float GetHealth()
        {
            return AMOUNT_OF_HEALTH;
        }
    }
}