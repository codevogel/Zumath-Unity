using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using References;
using Nodes;
using States.Node;


namespace PowerUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class PowerUp : MonoBehaviour
    {
        public const float DIAMETER = 0.75f;

        public bool alive;

        void Awake()
        {
            Init();
        }

        public void Init()
        {
            alive = true;
        }

        public void SetColor()
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.color = Color.clear;
        }

        // If a node hits the PowerUp this will say what happens
        public void OnTriggerEnter2D(Collider2D collision)
        {
            NumberNode otherNode = collision.GetComponent<NumberNode>();

            if (otherNode != null)
            {
                // Prevent collision with Preview nodes
                if (otherNode.state == NodeState.PREVIEW)
                {
                    return;
                }
                // Prevents collision detection with nodes in the gutter
                if (NodeManager.Contains(otherNode))
                {
                    return;
                }

                // Tells what happens when collision happens
                PowerUpManager.triggerPowerUp = true;
                Kill();
            }
        }

        public void Kill()
        {
            alive = false;
            DestroyDeadPowerUps();
        }

        public void DestroyDeadPowerUps()
        {
            List<PowerUp> powerUpsToDestroy = new List<PowerUp>();

            foreach (PowerUp powerUp in PowerUpManager.GetPowerUps())
            {
                if (!alive)
                {
                    powerUpsToDestroy.Add(powerUp);
                }
            }

            foreach (PowerUp powerUp in powerUpsToDestroy)
            {
                PowerUpManager.RemovePowerUps(powerUp);
                Destroy(powerUp.gameObject);
            }
        }
    }
}
