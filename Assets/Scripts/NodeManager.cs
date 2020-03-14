using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    static class NodeManager
    {
        private static List<NumberNode> nodeList = new List<NumberNode>();

        public static void InsertNode(int index, NumberNode node)
        {
            nodeList.Insert(index, node);
        }

        public static int GetIndex(NumberNode node)
        {
            return nodeList.IndexOf(node);
        }

        public static List<NumberNode> GetNodes()
        {
            return nodeList;
        }

        public static void StartMovingNodes()
        {
            foreach (NumberNode node in nodeList)
            {
                node.StartMoving();
            }
        }

        public static void MoveNodes()
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                // Node in front
                if (i == 0)
                {
                    nodeList[i].Move();
                }
                else {
                    NumberNode currentNode = nodeList[i];
                    NumberNode nodeInFront = nodeList[i - 1];
                    NumberNode nodeBehind = null;
                    if (i != nodeList.Count - 1)
                    {
                        nodeBehind = nodeList[i + 1];
                    }
                    // Check for collision with node in front
                    if (currentNode.IsTouching(nodeInFront) || currentNode.WasTouching(nodeInFront))
                    {
                        currentNode.ReverseOutOfNode(nodeInFront);
                    }
                    else
                    {
                        if (nodeBehind != null)
                        {
                            if (currentNode.IsTouching(nodeBehind) || currentNode.WasTouching(nodeBehind))
                            {
                                currentNode.GoForwardsOutOfNode(nodeBehind);
                            }
                            else
                            {
                                currentNode.Move();
                            }
                        }
                        else
                        {
                            currentNode.Move();
                        }
                    }
                }
            }
        }
    }
}
