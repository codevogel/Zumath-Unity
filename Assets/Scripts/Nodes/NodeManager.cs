using System.Collections.Generic;
using Follower;
using MathLists;
using States.Game;
using States.Node;

namespace Nodes
{
    public static class NodeManager
    {

        // Nodes are placed in this list like they are placed in the path.
        // The first node encountered when you go from the start of the path to the end of the path,
        // is the first node in this list.
        // The final node encountered is the final node in this list.
        private static NumberList numberList = new NumberList();

        private static NodeDestroyer nodeDestroyer;

        private static NumberNode newlyInsertedNode = null;

        public static int target = 5;

        private static bool dispersing;

        public static void Init(NodeDestroyer _nodeDestroyer)
        {
            nodeDestroyer = _nodeDestroyer;
        }

        // Newly added nodes are placed in the front of the list, 
        // so nodes in the list are ordered like they are on the path 
        // (from start to end)
        public static void AddNode(NumberNode node)
        {
            numberList.numberLinkedList.AddFirst(node);
        }

        public static void RemoveNode(NumberNode node)
        {
            numberList.numberLinkedList.Remove(node);
        }

        public static void InsertAtPlaceOf(LinkedListNode<NumberNode> nodeInGutter, NumberNode node)
        {
            newlyInsertedNode = node;
            dispersing = true;

            float distTravelled = nodeInGutter.Value.pathFollower.distanceTravelled - NumberNode.RADIUS / 2f;
            newlyInsertedNode.pathFollower.SetDistanceTravelled(distTravelled);
            newlyInsertedNode.transform.position = nodeInGutter.Value.pathFollower.pathCreator.path.GetPointAtDistance(distTravelled);

            //TODO: weghalen dat dit nodig is (projectile state zorgt voor de nodecontroller)
            node.SetState(NodeState.STANDSTILL);

            numberList.numberLinkedList.AddBefore(nodeInGutter, newlyInsertedNode);
        }

        public static bool Contains(NumberNode node)
        {
            if (numberList.numberLinkedList.Contains(node))
            {
                return true;
            }
            return false;
        }

        public static void Update()
        {
            nodeDestroyer.DestroyDeadNodes();

            switch (GameStateManager.GetGameState())
            {
                case GameState.SPAWNING:
                    return;
                case GameState.PREINSERTION:
                    MoveNodesForward();
                    return;
                case GameState.DISPERSING:
                    DisperseNodes();
                    return;
                case GameState.RESETTING:
                    return;
                case GameState.PAUSED:
                    return;
            }
        }

        public static void MoveNodesForward()
        {
            if (numberList != null)
            {
                if (numberList.numberLinkedList.Count > 0)
                {
                    MoveNode(MoveType.FORWARD, numberList.numberLinkedList.First);
                }
            }
        }

        public static void MoveNode(MoveType moveType, LinkedListNode<NumberNode> node)
        {
            LinkedListNode<NumberNode> prevNode = node.Previous;
            LinkedListNode<NumberNode> nextNode = node.Next;

            switch (moveType)
            {
                case MoveType.FORWARD:
                    node.Value.pathFollower.Follow(moveType);
                    if (nextNode != null)
                    {
                        if (node.Value.IsTouching(nextNode.Value))
                        {
                            MoveNode(MoveType.FORWARD, nextNode);
                        }
                    }
                    return;
                case MoveType.BACKWARD:
                    if (nextNode != null)
                    {
                        if (node.Value.IsTouching(nextNode.Value))
                        {
                            if (prevNode != null)
                            {
                                if (node.Value.IsTouching(prevNode.Value))
                                {
                                    MoveNode(MoveType.BACKWARD, prevNode);
                                }
                            }
                        }
                    }
                    node.Value.pathFollower.Follow(moveType);
                    return;
            }
        }

        private static void DisperseNodes()
        {
            LinkedListNode<NumberNode> insertedNode = numberList.numberLinkedList.Find(newlyInsertedNode);
            LinkedListNode<NumberNode> nextNode = insertedNode.Next;
            LinkedListNode<NumberNode> prevNode = insertedNode.Previous;
            bool touching = false;

            // if node in front exists
            if (nextNode != null)
            {
                // if inserted node is touching the next node
                if (insertedNode.Value.IsTouching(nextNode.Value))
                {
                    touching = true;
                    MoveNode(MoveType.FORWARD, nextNode);
                }
            }
            // if node behind exists
            if (prevNode != null)
            {
                // if inserted node is touching the enode behind
                if (insertedNode.Value.IsTouching(prevNode.Value))
                {
                    touching = true;
                    MoveNode(MoveType.BACKWARD, prevNode);
                }
            }
            if (!touching)
            {
                OnDispersed();
            }
        }

        private static void OnDispersed()
        {
            int index = numberList.GetIndexOfNode(newlyInsertedNode);
            if (numberList.CheckForComboAt(index, target))
            {
                target = UnityEngine.Random.Range(NumberList.BOUND_LOW, NumberList.BOUND_HIGH);
                // begin te checken of alle ballen elkaar aandrijven
                // dan mag kanon weer schieten
            }
            else
            {
                // kanon mag weer schieten
            }

            newlyInsertedNode = null;
            dispersing = false;

        }

        public static float GetSpeed()
        {
            if (dispersing)
            {
                return 2f;
            }
            else
            {
                return 1f;
            }
        }

        public static LinkedList<NumberNode> GetNodes()
        {
            if (numberList != null)
            {
                return numberList.numberLinkedList;
            }
            return new LinkedList<NumberNode>();
        }

    }
}

