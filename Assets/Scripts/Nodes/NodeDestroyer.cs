using References;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using Assets.Scripts.Particles;
using Assets.Scripts.Audio;

namespace Nodes
{
    public class NodeDestroyer : MonoBehaviour
    {
        private HealthController healthController;
        public AudioPlayer nodeDestroyedAudio;

        private void Awake()
        {
            gameObject.tag = Tags.NODE_DESTROYER;
            healthController = GameObject.FindGameObjectWithTag(Tags.HEALTH).GetComponent<HealthController>();
        }
            
        public void DestroyDeadNodes()
        {
            List<NumberNode> nodesToDestroy = new List<NumberNode>();

            foreach (NumberNode node in NodeManager.GetNodes())
            {
                if (!node.alive)
                {
                    nodesToDestroy.Add(node);
                    ParticlesList.Add(node.transform.position); 
                    ScoreAdd.AddScore(10);
                    nodeDestroyedAudio.ShouldPlay = true;
                }
                else
                {
                    if (node.pathFollower.distanceTravelled >= node.pathFollower.pathCreator.path.length)
                    {
                        nodesToDestroy.Add(node);
                        
                        healthController.RemoveLife();
                    }
                }
            }

            foreach (NumberNode node in nodesToDestroy)
            {
                ScoreAdd.SetFurthestDistanceTravelled(node.pathFollower.distanceTravelled);
                NodeManager.RemoveNode(node);
                Destroy(node.gameObject);
            }
        }
    }
}

