using References;
using System.Collections.Generic;
using UnityEngine;

namespace Nodes
{
    public class NodeDestroyer : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.tag = Tags.NODE_DESTROYER;
        }

        public void DestroyDeadNodes()
        {
            List<NumberNode> nodesToDestroy = new List<NumberNode>();

            foreach (NumberNode node in NodeManager.GetNodes())
            {
                if (!node.alive)
                {
                    nodesToDestroy.Add(node);
                }
                else
                {
                    if (node.pathFollower.distanceTravelled >= node.pathFollower.pathCreator.path.length)
                    {
                        nodesToDestroy.Add(node);
                        // TODO: apply penalty
                    }
                }
            }

            foreach (NumberNode node in nodesToDestroy)
            {
                NodeManager.RemoveNode(node);
                Destroy(node.gameObject);
            }
        }
    }
}

