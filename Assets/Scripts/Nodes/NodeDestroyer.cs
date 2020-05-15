using References;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using AnimationManagers;

namespace Nodes
{
    public class NodeDestroyer : MonoBehaviour
    {
        private HealthController healthController;
        private ScreenShake screenShake;

        private void Awake()
        {
            gameObject.tag = Tags.NODE_DESTROYER;
            healthController = GameObject.FindGameObjectWithTag(Tags.HEALTH).GetComponent<HealthController>();
            screenShake = GameObject.FindGameObjectWithTag(Tags.SCREENSHAKE).GetComponent<ScreenShake>();
        }
            
        public void DestroyDeadNodes()
        {
            List<NumberNode> nodesToDestroy = new List<NumberNode>();

            foreach (NumberNode node in NodeManager.GetNodes())
            {
                if (!node.alive)
                {
                    nodesToDestroy.Add(node);
                    ScoreAdd.AddScore(10);
                }
                else
                {
                    if (node.pathFollower.distanceTravelled >= node.pathFollower.pathCreator.path.length)
                    {
                        nodesToDestroy.Add(node);
                        
                        healthController.RemoveLife();
                        screenShake.CamShake();
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

