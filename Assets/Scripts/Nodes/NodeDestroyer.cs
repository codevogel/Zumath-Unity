using References;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using AnimationManagers;
using Follower;
using States.Game;
using Assets.Scripts.Particles;
using Assets.Scripts.Audio;

namespace Nodes
{
    // This script makes this gameobject responsible for destroying nodes, and should be used only once.
    public class NodeDestroyer : MonoBehaviour
    {
        private HealthController healthController;
        private ScreenShake screenShake;
        public AudioPlayer nodeDestroyedAudio;

        private void Awake()
        {
            gameObject.tag = Tags.NODE_DESTROYER;
            healthController = GameObject.FindGameObjectWithTag(Tags.HEALTH).GetComponent<HealthController>();
            screenShake = GameObject.FindGameObjectWithTag(Tags.SCREENSHAKE).GetComponent<ScreenShake>();
        }
            
        // Destroys dead nodes from the NodeManager
        public void DestroyDeadNodes()
        {
            List<NumberNode> nodesToDestroy = new List<NumberNode>();

            // Loop over each node and mark them for destruction
            foreach (NumberNode node in NodeManager.GetNodes())
            {
                // If node is dead
                if (!node.alive)
                {
                    // Mark node eligible for destruction
                    nodesToDestroy.Add(node);


                    ParticlesList.Add(node.transform.position); 
                    ScoreAdd.AddScore(10);
                    nodeDestroyedAudio.ShouldPlay = true;
                }
                else
                {
                    // If node is alive, but has reached the end of the gutter
                    if (node.pathFollower.distanceTravelled >= node.pathFollower.pathCreator.path.length)
                    {
                        // Mark node eligible for destruction
                        nodesToDestroy.Add(node);

                        screenShake.CamShake();
                        healthController.RemoveLife();
                        GameStateManager.SwitchToMoveBack();
                    }
                }
            }

            // Destroy nodes that are eligible for destruction
            // (Do this afterwards to not mess with the array during the foreach loop)
            foreach (NumberNode node in nodesToDestroy)
            {
                ScoreAdd.SetFurthestDistanceTravelled(node.pathFollower.distanceTravelled);
                NodeManager.RemoveNode(node);
                Destroy(node.gameObject);
            }
        }
    }
}

